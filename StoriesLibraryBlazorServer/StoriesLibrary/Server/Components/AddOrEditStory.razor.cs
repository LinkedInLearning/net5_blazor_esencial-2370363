using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using StoriesLibrary.Config;
using StoriesLibrary.Data;
using StoriesLibrary.Entities;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace StoriesLibrary.Components
{
	public partial class AddOrEditStory : IAsyncDisposable
	{

		public enum FormMode
		{
			Add,
			Edit
		}

		[Inject]
		private StoriesStorageConfig storiesStorageConfig { get; set; }

		[Inject]
		private ILocalStorageService localStorageService { get; set; }

		[Inject]
		private IDbContextFactory<StoriesContext> contextFactory { get; set; }

		[Inject]
		private NavigationManager navigationManager { get; set; }

		private bool storySaved = false;

		private Timer timer;

		private Story model;

		private bool storyNotFound;


		private PropertyValues databaseValues, currentValues, originalValues;

		private InputFileChangeEventArgs fileInfo;

		private string storageKey;

		private StoriesContext context;

		[Parameter]
		public FormMode Mode { get; set; }

		[Parameter]
		public int? StoryId { get; set; }

		protected override void OnInitialized()
		{
			context = contextFactory.CreateDbContext();
		}

		protected override async Task OnParametersSetAsync()
		{
			if (Mode == FormMode.Edit && StoryId is null)
			{
				throw new InvalidOperationException("If you create this component in edit mode, you must provide a story identifier to edit the story.");
			}
			if (Mode == FormMode.Edit)
			{
				model = await context.Stories.SingleOrDefaultAsync(s => s.Id == StoryId);
				storyNotFound = model is null;
			}
			else
			{
				model = new Story();
			}
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender && !storyNotFound)
			{
				storageKey = (new Uri(navigationManager.Uri)).AbsolutePath.Replace("/", "_") + "_storyText";
				var storedText = await localStorageService.ContainKeyAsync(storageKey) ? await localStorageService.GetItemAsync<string>(storageKey) : null;
				if (!string.IsNullOrWhiteSpace(storedText))
				{
					model.Text = storedText;
					StateHasChanged();
				}
				timer = new Timer { Interval = 5000 };
				timer.Elapsed += Timer_Elapsed;
				timer.Start();
			}
		}

		private async Task InputFile_Change(InputFileChangeEventArgs e)
		{
			fileInfo = e;
		}


		private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			await this.InvokeAsync(SaveStoryTextInStorage);
		}

		private async Task SaveStoryTextInStorage()
		{
			await localStorageService.SetItemAsync(storageKey, model.Text);
		}
		private async Task SaveStoryAsync()
		{
			try
			{
				if (Mode == FormMode.Add)
				{
					model.Author = "Juanjo Montiel";
					model.PublishedDate = DateTime.UtcNow;
					context.Stories.Add(model);
				}
				await context.SaveChangesAsync();
				if (fileInfo != null)
				{
					var path = Path.Combine(Directory.GetCurrentDirectory(), storiesStorageConfig.Path, $"{model.Id}.mp3");
					var dir = Path.GetDirectoryName(path);
					if (!Directory.Exists(dir))
					{
						Directory.CreateDirectory(dir);
					}
					using var fileStream = File.OpenWrite(path);
					await fileInfo.File.OpenReadStream(storiesStorageConfig.FileMaxSize).CopyToAsync(fileStream);
				}
				storySaved = true;
			}
			catch (DbUpdateConcurrencyException ex)
			{
				var entry = ex.Entries.First();
				currentValues = entry.CurrentValues;
				originalValues = entry.OriginalValues;
				databaseValues = await entry.GetDatabaseValuesAsync();
			}
		}

		private async Task ResolveConflictMyVersion()
		{
			originalValues.SetValues(databaseValues);
			await SaveStoryAsync();
		}

		private void ResolveConflictLeaveSaved()
		{
			navigationManager.NavigateTo("admin/stories");
		}

		private void ResolveConflictEditAgain()
		{
			originalValues.SetValues(databaseValues);
			databaseValues = currentValues = null;
		}

		public async ValueTask DisposeAsync()
		{
			if (timer != null)
			{
				timer.Elapsed -= Timer_Elapsed;
			}
			timer?.Stop();
			timer?.Dispose();

			context?.DisposeAsync();
		}

	}
}
