using Microsoft.AspNetCore.Components;

using StoriesLibrary.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesLibrary.Components
{
	public partial class EnhancedInput
	{
		[Parameter]
		public int MaxLength { get; set; }

		[Parameter(CaptureUnmatchedValues = true)]
		public Dictionary<string, object> AdditionalAttributes { get; set; }

		[Parameter]
		public EventCallback<FillingPercentageChangedEventArgs> OnFillingPercentageChanged { get; set; }

		private async Task InputChanged(ChangeEventArgs e)
		{
			var length = ((string)e.Value).Length;

			if (MaxLength == 0)
			{
				await OnFillingPercentageChanged.InvokeAsync(new FillingPercentageChangedEventArgs { Length = length, FillingPercentage = 0 });
			}
			else
			{
				var percentage = length * 100 / MaxLength;
				await OnFillingPercentageChanged.InvokeAsync(new FillingPercentageChangedEventArgs { FillingPercentage = percentage, Length = length });
			}
		}
	}
}
