using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

using StoriesLibrary.Components;
using StoriesLibrary.Data;
using StoriesLibrary.Entities;
using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
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
		private IDbContextFactory<StoriesContext>  contextFactory{ get; set; }

		protected override async Task OnInitializedAsync()
		{
			var context = contextFactory.CreateDbContext();
			stories = await context.Stories.OrderByDescending(s => s.PublishedDate).ToListAsync();
		}

		private void EditStory(Story story)
		{
		}

		private void DeleteStory(Story story)
		{
		}

		private async Task LoadStoryDetails(Story story)
		{
			var context = contextFactory.CreateDbContext();
			selectedStory = await context.Stories.SingleOrDefaultAsync();
			storyNotFound = selectedStory is null;
		}
	}
}
