using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using StoriesLibrary.Config;
using StoriesLibrary.Data;
using StoriesLibrary.Entities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Controllers
{
	[Route("/[Controller]")]
	public class StoriesController : Controller
	{

		private readonly IDbContextFactory<StoriesContext> contextFactory;

		private readonly StoriesStorageConfig storageConfig;

		public StoriesController(IDbContextFactory<StoriesContext> contextFactory, StoriesStorageConfig storageConfig)
		{
			this.contextFactory = contextFactory;
			this.storageConfig = storageConfig;
		}

		[HttpGet]
		[Route("audioFile/{id:int}")]
		public async Task<IActionResult> AudioFile(int id)
		{
			var context = contextFactory.CreateDbContext();
			var story = await context.Stories.SingleOrDefaultAsync(s => s.Id == id);
			if (story is null)
			{
				return NotFound();
			}

			var audioPath = Path.Combine(Directory.GetCurrentDirectory(), storageConfig.Path, $"{story.Id}.mp3");
			if (!System.IO.File.Exists(audioPath))
			{
				return NotFound();
			}

			return File(System.IO.File.OpenRead(audioPath), "audio/mpeg", true);
		}
	}
}
