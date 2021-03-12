using Microsoft.AspNetCore.Components.Forms;

using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Services
{
	public interface IStoriesService
	{
		Task<List<Story>> GetNoveltiesAsync(StoriesService.NoveltiesScope scope);
		Task<List<Story>> GetAllAsync();
		Task AddStoryAsync(Story story, IBrowserFile file);

	}
}