using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

using StoriesLibrary.Components;
using StoriesLibrary.Config;
using StoriesLibrary.Data;
using StoriesLibrary.Entities;
using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Pages.Admin.Stories
{
	public partial class Index
	{
		private List<Story> stories;

		private Story selectedStory;

		private bool storyNotFound = false;

		[Inject]
		private IDbContextFactory<StoriesContext> contextFactory { get; set; }

		[Inject]
		private StoriesStorageConfig storageConfig { get; set; }

		[Inject]
		private IJSRuntime jsRuntime { get; set; }

		[Inject]
		private ILogger<Index> logger { get; set; }

		[Inject]
		private NavigationManager navigationManager { get; set; }

		protected override async Task OnInitializedAsync()
		{
			using var context = contextFactory.CreateDbContext();
			stories = await context.Stories.OrderByDescending(s => s.PublishedDate).ToListAsync();
		}

		private void EditStory(Story story)
		{
			navigationManager.NavigateTo($"admin/stories/edit/{story.Id}");
		}

		private async Task DeleteStory(Story story)
		{
			try
			{
				bool confirm = await jsRuntime.InvokeAsync<bool>("confirm", $"¿Seguro que deseas eliminar la historia {story.Title}, de {story.Author}?");
				if (confirm)
				{
					var context = contextFactory.CreateDbContext();
					var storyToDelete = await context.Stories.SingleOrDefaultAsync(s => s.Id == story.Id);
					context.Stories.Remove(storyToDelete);
					context.SaveChanges();
					stories.Remove(story);
					var audioPath = Path.Combine(Directory.GetCurrentDirectory(), storageConfig.Path, $"{story.Id}.mp3");
					if (File.Exists(audioPath))
					{
						File.Delete(audioPath);
					}
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Error when deleting a story.");
				await jsRuntime.InvokeVoidAsync("alert", "Error al eliminar la historia. Disculpa las molestias.");
			}
		}

		private async Task LoadStoryDetails(Story story)
		{
			using var context = contextFactory.CreateDbContext();
			selectedStory = await context.Stories.SingleOrDefaultAsync(s => s.Id == story.Id);
			storyNotFound = selectedStory is null;
		}
	}
}
