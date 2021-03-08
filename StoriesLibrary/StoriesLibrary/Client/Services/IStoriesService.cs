using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;

namespace StoriesLibrary.Client.Services
{
	public interface IStoriesService
	{
		List<Story> GetNovelties(StoriesService.NoveltiesScope scope);
		List<Story> GetAll();

	}
}