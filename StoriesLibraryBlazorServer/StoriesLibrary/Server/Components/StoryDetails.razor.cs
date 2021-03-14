using Microsoft.AspNetCore.Components;

using StoriesLibrary.Config;
using StoriesLibrary.Entities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Components
{
	public partial class StoryDetails
	{
		private int? previousStoryId;

		private bool audioExists = false;

		[Inject]
		private StoriesStorageConfig storiesStorageConfig { get; set; }

		[Parameter]
		public Story Story { get; set; }

		
		protected override void OnParametersSet()
		{
			var audioPath = Path.Combine(Directory.GetCurrentDirectory(), storiesStorageConfig.Path, $"{Story.Id}.mp3");
			audioExists = File.Exists(audioPath);
		}
		protected override bool ShouldRender()
		{
			if (previousStoryId is null || previousStoryId.Value != Story.Id)
			{
				previousStoryId = Story.Id;
				return true;
			}
			return false;
		}

		protected override void OnAfterRender(bool firstRender)
		{
			if (firstRender && Story != null)
			{
				previousStoryId = Story.Id;
			}
		}
	}
}