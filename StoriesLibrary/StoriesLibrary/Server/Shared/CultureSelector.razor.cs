using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Shared
{
	public partial class CultureSelector
	{
		[Inject]
		private NavigationManager navigationManager { get; set; }

		[Inject]
		private IStringLocalizer<CultureSelector> localizer { get; set; }

		[Inject]
		private RequestLocalizationOptions localizationOptions { get; set; }

		private CultureInfo currentCulture => CultureInfo.CurrentUICulture;
	}
}
