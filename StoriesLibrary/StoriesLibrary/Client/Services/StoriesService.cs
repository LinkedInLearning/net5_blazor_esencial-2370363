using Microsoft.Extensions.Logging;

using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Net.Http;
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

		private async Task<List<Story>> GetStoriesListAsync(string apiUrl)
		{
			if (apiUrl is null)
			{
				throw new ArgumentNullException(nameof(apiUrl));
			}

			try
			{
				var response = await httpClient.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				var stories = JsonSerializer.Deserialize<List<Story>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
				return stories;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "error when retrieving stories from API.");
				throw ex;
			}
		}
	}
}
