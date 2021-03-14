using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Pages
{
	[AllowAnonymous]
	public partial class Index
	{

		[CascadingParameter(Name = "numberOfSubscribers")]
		private int numberOfStories { get; set; }
[Inject]
		private IStringLocalizer<Index> localizer { get; set; }

	}
}
