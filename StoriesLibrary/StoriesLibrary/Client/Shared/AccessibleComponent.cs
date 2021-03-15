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
	public class AccessibleComponent : ComponentBase
	{

		[CascadingParameter]
		protected AccessibilityContext AccessibilityContext { get; set; }

		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (!string.IsNullOrWhiteSpace(AccessibilityContext.CssSelectorToFocus))
			{
				await jsRuntime.InvokeVoidAsync("accessibilityFunctions.focusByQuerySelector", AccessibilityContext.CssSelectorToFocus);
				AccessibilityContext.CssSelectorToFocus = null;
			}
		}
	}
}
