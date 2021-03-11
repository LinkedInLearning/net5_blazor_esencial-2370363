using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using StoriesLibrary.Client.Config;
using StoriesLibrary.Client.Services;

using System;
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
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddSingleton<IStoriesService, StoriesService>();

			AddConfiguration(builder);

			await builder.Build().RunAsync();
		}

		private static void AddConfiguration(WebAssemblyHostBuilder builder)
		{
			var paginationConfig = new PaginationConfig();
			builder.Configuration.GetSection("Pagination").Bind(paginationConfig);
			builder.Services.AddSingleton(paginationConfig);
		}
	}
}
