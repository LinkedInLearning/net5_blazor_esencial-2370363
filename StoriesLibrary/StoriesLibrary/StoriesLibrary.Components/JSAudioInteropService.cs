using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System;
using System.Threading.Tasks;

namespace StoriesLibrary.Components
{
	public class JSAudioInteropService : IAsyncDisposable
	{
		
		private readonly Lazy<Task<IJSObjectReference>> moduleTask;

		public JSAudioInteropService(IJSRuntime jsRuntime)
		{
			moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
			   "import", "./_content/StoriesLibrary.Components/audioFunctions.js").AsTask());
		}

		public async Task PlayAudioAsync(ElementReference reference)
		{
			var module = await moduleTask.Value;
			await module.InvokeVoidAsync("playAudio", reference);
		}
		public async Task StopAudioAsync(ElementReference reference)
		{
			var module = await moduleTask.Value;
			await module.InvokeVoidAsync("stopAudio", reference);
		}

		public async ValueTask DisposeAsync()
		{
			if (moduleTask.IsValueCreated)
			{
				var module = await moduleTask.Value;
				await module.DisposeAsync();
			}
		}
	}
}
