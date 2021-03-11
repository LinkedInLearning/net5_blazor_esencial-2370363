using Microsoft.AspNetCore.Mvc;

using StoriesLibrary.Server.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Server.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class StoriesController : Controller
	{

		private readonly IStoriesService storiesService;

		public StoriesController(IStoriesService storiesService)
		{
			this.storiesService = storiesService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return Ok(storiesService.GetAll());
		}

		[HttpGet("novelties")]
		public IActionResult Novelties(string scope)
		{
			if (!Enum.TryParse<StoriesService.NoveltiesScope>(scope, true, out var parsedScope))
			{
				ModelState.AddModelError("scope", "The scope is invalid.");
				return BadRequest(ModelState);
			}
			return Ok(storiesService.GetNovelties(parsedScope));
		}
	}
}
