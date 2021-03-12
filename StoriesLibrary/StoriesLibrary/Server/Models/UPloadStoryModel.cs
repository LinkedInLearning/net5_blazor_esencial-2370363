using Microsoft.AspNetCore.Http;

using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Server.Models
{
	public class UPloadStoryModel : Story
	{

		public IFormFile File { get; set; }

	}
}
