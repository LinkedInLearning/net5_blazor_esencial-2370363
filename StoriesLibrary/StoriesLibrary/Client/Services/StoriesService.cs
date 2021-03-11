using Microsoft.Extensions.Logging;

using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Services
{
	public class StoriesService : IStoriesService
	{
		public enum NoveltiesScope
		{
			Today,
			Week,
			Month
		}

		private readonly HttpClient httpClient;

		private readonly ILogger<StoriesService> logger;

		public StoriesService(HttpClient client, ILogger<StoriesService> logger)
		{
			this.httpClient = client;
			this.logger = logger;
		}

		public Task<List<Story>> GetNoveltiesAsync(NoveltiesScope scope) => GetStoriesListAsync($"api/stories/novelties?scope={scope}");

		public Task<List<Story>> GetAllAsync() => GetStoriesListAsync("api/stories/");

		private Task<List<Story>> GetStoriesListAsync(string apiUrl) =>
			httpClient.GetFromJsonAsync < List<Story>>(apiUrl);
	}
}
