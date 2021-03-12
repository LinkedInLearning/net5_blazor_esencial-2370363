using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using StoriesLibrary.Client.Extensions;
using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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

		public async Task AddStoryAsync(Story story, IBrowserFile file)
		{
			var storyInfo = new Dictionary<string, string>()
			{
				{ "Title", story.Title },
				{ "Author", story.Author },
				{ "Category", story.Category },
				{ "PublishedDate", story.PublishedDate.ToString("o") },
				{ "Text", story.Text }
			};
			MultipartFormDataContent formDataContent = new MultipartFormDataContent();
			formDataContent.AddDictionaryValues(storyInfo);
			var fileContent = new StreamContent(file.OpenReadStream(104857600));
			fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
			{
				Name = "File",
				FileName = file.Name
			};
			formDataContent.Add(fileContent);
			await httpClient.PostAsync("api/stories", formDataContent);
		}

		

			private Task<List<Story>> GetStoriesListAsync(string apiUrl) =>
			httpClient.GetFromJsonAsync < List<Story>>(apiUrl);
	}
}
