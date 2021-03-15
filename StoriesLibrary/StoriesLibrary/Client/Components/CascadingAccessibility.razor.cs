using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using StoriesLibrary.Client.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Components
{
	public partial class CascadingAccessibility
	{
		private AccessibilityContext accessibilityContext = new AccessibilityContext();

		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		[Parameter]
		public RenderFragment ChildContent { get; set; }

	}
}
