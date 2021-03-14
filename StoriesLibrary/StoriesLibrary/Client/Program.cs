using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using StoriesLibrary.Client.Config;
using StoriesLibrary.Client.Services;

using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoriesLibrary.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.Logging.AddConfiguration(builder.Configuration.GetSection("Loggin"));
			builder.Services.AddLocalization();
			builder.Services.AddHttpClient("StoriesLibrary.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
				.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

			// Supply HttpClient instances that include access tokens when making requests to the server project
			builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("StoriesLibrary.ServerAPI"));

			builder.Services.AddApiAuthorization();

			builder.Services.AddScoped<IStoriesService, StoriesService>();
			builder.Services.AddBlazoredLocalStorage();
			AddConfiguration(builder);

			var host = builder.Build();
			var localStorageService = host.Services.GetRequiredService<ILocalStorageService>();
			if (await localStorageService.ContainKeyAsync("blazorCulture"))
			{
				var cultureStr = await localStorageService.GetItemAsync<string>("blazorCulture");
				if (!string.IsNullOrWhiteSpace(cultureStr))
				{
					var culture = new CultureInfo(cultureStr);
					CultureInfo.DefaultThreadCurrentCulture = culture;
					CultureInfo.DefaultThreadCurrentUICulture = culture;
				}
			}
			await host.RunAsync();
		}

		private static void AddConfiguration(WebAssemblyHostBuilder builder)
		{
			var paginationConfig = new PaginationConfig();
			builder.Configuration.GetSection("Pagination").Bind(paginationConfig);
			builder.Services.AddSingleton(paginationConfig);
		}
	}
}
