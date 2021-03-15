using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Shared
{
	public partial class CultureSelector
	{
		private CultureInfo[] supportedCultures = new[]
	{
		new CultureInfo("es-ES"),
		new CultureInfo("en-US"),
	};

		[Inject]
		private NavigationManager navigationManager { get; set; }

		[Inject]
		private ILocalStorageService localStorageService { get; set; }

		private CultureInfo currentCulture => CultureInfo.CurrentUICulture;

		private async Task SetCultureAsync(string culture)
		{
			if (culture != currentCulture.Name)
			{
				await localStorageService.SetItemAsync("blazorCulture", culture);
				navigationManager.NavigateTo(navigationManager.Uri, forceLoad: true);
			}
		}
	}
}
