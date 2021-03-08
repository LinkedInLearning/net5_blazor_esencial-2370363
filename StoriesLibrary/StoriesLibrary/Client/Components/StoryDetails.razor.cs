using Microsoft.AspNetCore.Components;

using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Components
{
	public partial class StoryDetails
	{
		private int? previousStoryId;

		[Parameter]
		public Story Story { get; set; }

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