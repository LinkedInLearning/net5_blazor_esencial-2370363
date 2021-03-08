using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Shared
{
	public partial class PageFooter
	{

		[Parameter]
		public RenderFragment ChildContent { get; set; }
	}
}
