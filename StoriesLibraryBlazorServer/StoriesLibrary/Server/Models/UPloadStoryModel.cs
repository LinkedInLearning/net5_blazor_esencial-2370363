using Microsoft.AspNetCore.Http;

using StoriesLibrary.Entities;

namespace StoriesLibrary.Models
{
	public class UPloadStoryModel : Story
	{

		public IFormFile File { get; set; }

	}
}
