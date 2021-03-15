using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using StoriesLibrary.Client.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Shared
{
	public class AccessiblePage : ComponentBase
	{

		[CascadingParameter]
		private AccessibilityContext accessibilityContext { get; set; }

		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (!string.IsNullOrWhiteSpace(accessibilityContext.CssSelectorToFocus))
			{
				await jsRuntime.InvokeVoidAsync("accessibilityFunctions.focusByQuerySelector", accessibilityContext.CssSelectorToFocus);
			}
			else
			{
				await jsRuntime.InvokeVoidAsync("accessibilityFunctions.focusInHeader");
			}
		}
	}
}
