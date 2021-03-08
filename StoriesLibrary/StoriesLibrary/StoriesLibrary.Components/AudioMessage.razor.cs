using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesLibrary.Components
{
	public partial class AudioMessage
	{
		public enum MessageType
		{
			Error,
			Warning,
			Information
		}

		private string audioSource;

		private ElementReference audioReference;

		private readonly Dictionary<string, string> sourceTypes = new Dictionary<string, string>() {
				{ "wav", "audio/vnd.wave" },
				{ "mp3", "audio/mp3" },
				{ "ogg", "audio/ogg" }
			};
		private JSAudioInteropService AudioInteropService { get; set; }
		[Inject]
		private JSAudioInteropService audioInteropService { get; set; }

		[Parameter]
		public MessageType Type { get; set; }

		[Parameter(CaptureUnmatchedValues = true)]
		public Dictionary<string, object> additionalAttributes { get; set; }

		protected override void OnParametersSet()
		{
			audioSource = Type switch
			{
				MessageType.Error => "error",
				MessageType.Information => "info",
				MessageType.Warning => "warn",
				_ => "info"
			};
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				PlayAsync();
			}
		}

		public async Task PlayAsync()
		{
			await audioInteropService.StopAudioAsync(audioReference);
			await audioInteropService.PlayAudioAsync(audioReference);
		}
	}
}
