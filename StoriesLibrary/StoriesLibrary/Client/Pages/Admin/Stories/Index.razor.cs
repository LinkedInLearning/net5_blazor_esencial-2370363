using Microsoft.AspNetCore.Components;

using StoriesLibrary.Client.Components;
using StoriesLibrary.Client.Services;
using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Pages.Admin.Stories
{
	public partial class Index
	{
		private List<Story> stories;

		private Story selectedStory;

		[Inject]
		private IStoriesService storiesService { get; set; }


		protected override void OnInitialized()
		{
			stories = storiesService.GetAll();
		}

		private void EditStory(Story story)
		{
		}

		private void DeleteStory(Story story)
		{
		}

		private void LoadStoryDetails(Story story)
		{
			selectedStory = story;
		}
	}
}
