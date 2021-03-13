using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

using StoriesLibrary.Data;
using StoriesLibrary.Entities;

using System;
using System.Threading.Tasks;
using System.Timers;

namespace StoriesLibrary.Pages.Stories
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
		private IDbContextFactory<StoriesContext> contextFactory { get; set; }

		private bool storySaved= false;

		private Timer timer;

		private Story model = new Story();

		private InputFileChangeEventArgs fileInfo;

		[Parameter]
		public FormMode Mode { get; set; }

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				var storedText = await localStorageService.ContainKeyAsync("storyText") ? await localStorageService.GetItemAsync<string>("storyText") : null;
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

		private async Task SaveStory()
		{
			model.Author = "Juanjo Montiel";
			// await contextFactory.AddStoryAsync(model, fileInfo.File);
			storySaved = true;
		}


		private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			await this.InvokeAsync(SaveStoryTextInStorage);
		}

		private async Task SaveStoryTextInStorage()
		{
			await localStorageService.SetItemAsync("storyText", model.Text);
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
