using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;

using StoriesLibrary.Client.Entities;
using StoriesLibrary.Client.Services;
using StoriesLibrary.Client.Models;
using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace StoriesLibrary.Client.Components
{
	public partial class AddOrEdit : IDisposable
	{

		public enum FormMode
		{
			Add,
			Edit
		}


		[Inject]
		private ILocalStorageService localStorageService { get; set; }

		[Inject]
		private IStoriesService storiesService { get; set; }

		[Inject]
		private NavigationManager navigationManager { get; set; }

		[CascadingParameter]
		private Task<AuthenticationState> authenticationStateTask { get; set; }

		private bool storySaved= false;

		private Timer timer;

		private StoryModel model = new StoryModel();

		private EditContext editContext;

		private string storageKey;
		

		private CustomValidator customValidator;

		[Parameter]
		public FormMode Mode { get; set; }

		protected override void OnInitialized()
		{
			storageKey = new Uri(navigationManager.Uri).AbsolutePath.Replace("/", "_") + "_storyText";
			editContext = new EditContext(model);
		}
		
		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
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
			model.Mp3File = e.File;
		}

		private async Task SaveStory()
		{
			customValidator.ClearErrors();
			if (model.Mp3File != null)
			{
				if (model.Mp3File.ContentType != "audio/mpeg")
				{
					customValidator.DisplayErrors(new Dictionary<string, List<string>> { { "txtFile", new List<string> { "El archivo introducido parece no ser un fichero MP3 válido." } } });
					return;
				}
			}
			var authenticationState = await authenticationStateTask;
			await storiesService.AddStoryAsync(new Story { Title = model.Title, Author = authenticationState?.User?.Identity?.Name ?? "desconocido", PublishedDate = DateTime.UtcNow, Category = model.Category, Text = model.Text }, model.Mp3File);
			storySaved = true;
		}


		private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			await this.InvokeAsync(SaveStoryTextInStorage);
		}

		private async Task SaveStoryTextInStorage()
		{
			await localStorageService.SetItemAsync(storageKey, model.Text);
		}


		public void Dispose()
		{
			if (timer != null)
			{
				timer.Elapsed -= Timer_Elapsed;
			}
			timer?.Stop();
			timer?.Dispose();
		}
	}
}
