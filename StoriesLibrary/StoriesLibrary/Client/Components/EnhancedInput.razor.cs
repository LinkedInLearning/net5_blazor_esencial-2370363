using Microsoft.AspNetCore.Components;

using System.Collections.Generic;

namespace StoriesLibrary.Client.Components
{
	public partial class EnhancedInput
	{
		[Parameter(CaptureUnmatchedValues = true)]
		public Dictionary<string, object> AdditionalAttributes { get; set; }

	}
}
