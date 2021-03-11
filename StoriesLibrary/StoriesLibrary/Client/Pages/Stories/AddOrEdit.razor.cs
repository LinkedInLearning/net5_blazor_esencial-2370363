using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using StoriesLibrary.Client.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace StoriesLibrary.Client.Pages.Stories
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
		
		private int percentage;

		private Timer timer;

		private string storyText;

		[Parameter]
		public FormMode Mode { get; set; }

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				var storedText = await localStorageService.ContainKeyAsync("storyText") ? await localStorageService.GetItemAsync<string>("storyText") : null;
				if (!string.IsNullOrWhiteSpace(storedText))
				{
					storyText = storedText;
					StateHasChanged();
				}
				timer = new Timer { Interval = 5000 };
				timer.Elapsed += Timer_Elapsed;
				timer.Start();
			}
		}

		private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			await this.InvokeAsync(SaveStoryTextInStorage);
		}

		private async Task SaveStoryTextInStorage()
		{
			await localStorageService.SetItemAsync("storyText", storyText);
		}

		private void FillingPercentageChanged(FillingPercentageChangedEventArgs e)
		{
			percentage = e.FillingPercentage;
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
