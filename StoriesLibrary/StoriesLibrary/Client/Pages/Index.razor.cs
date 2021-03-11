using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Pages
{
	public partial class Index
	{

		[CascadingParameter(Name = "numberOfSubscribers")]
		private int numberOfStories { get; set; }

		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		private string name;

		private ElementReference audioRef;

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				name = await jsRuntime.InvokeAsync<string>("prompt", "¿Cómo te llamas?");
				await jsRuntime.InvokeVoidAsync("playAudio", audioRef);
				StateHasChanged();
			}
		}
	}
}
