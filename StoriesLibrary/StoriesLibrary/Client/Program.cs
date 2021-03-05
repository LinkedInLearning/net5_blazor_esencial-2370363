using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using StoriesLibrary.Client.Config;
using StoriesLibrary.Client.Services;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StoriesLibrary.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddSingleton<IStoriesService, StoriesService>();
			AddConfig(builder);
			await builder.Build().RunAsync();
		}

		private static void AddConfig(WebAssemblyHostBuilder builder)
		{
			var paginationConfig = new PaginationConfig();
			builder.Configuration.GetSection("pagination").Bind(paginationConfig);
			builder.Services.AddSingleton(paginationConfig);
		}
	}
}
