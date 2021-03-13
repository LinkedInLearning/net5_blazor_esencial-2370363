using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using StoriesLibrary.Data;
using StoriesLibrary.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Pages.Novelties
{
	public partial class Today
	{
		private List<Story> stories;

		private bool errorsWhenLoading = false;

		private Story selectedStory;
		
		private bool storyNotFound;

		[Inject]
		private ILogger<Today> logger { get; set; }

		[Inject]
		private IDbContextFactory<StoriesContext> contextFactory { get; set; }

		[Parameter]
		public int? PageNumber { get; set; }

		public override Task SetParametersAsync(ParameterView parameters)
		{
			logger.LogInformation("Se ha llamado a SetParametersAsync. Se van a ajustar los parámetros del componente. Llamando a la implementación base...");
			return base.SetParametersAsync(parameters);
		}

		protected override async Task OnInitializedAsync()
		{
			logger.LogInformation("Se ha llamado a OnInitialized. El componente se acaba de iniciar.");
			try
			{
				using var context = contextFactory.CreateDbContext();
				stories = await context.Stories.Where(s => s.PublishedDate.Date == DateTime.Now.Date).OrderByDescending(s => s.PublishedDate).ToListAsync();
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Error hwen loading stories.");
				errorsWhenLoading = true;
			}
		}

		protected override void OnParametersSet()
		{
			logger.LogInformation("Se ha llamado a OnParametersSet. Los parámetros ya está ajustados en el componente.");
			PageNumber = PageNumber ?? 1;
		}

		protected override Task OnAfterRenderAsync(bool firstRender)
		{
			logger.LogInformation($"El componente se acaba de renderizar. firstRender = {firstRender}.");
			return Task.CompletedTask;
		}

		private async Task LoadStoryDetails(Story story)
		{
			using var context = contextFactory.CreateDbContext();
			selectedStory = await context.Stories.SingleOrDefaultAsync(s => s.Id == story.Id);
			storyNotFound = selectedStory is null;
		}
	}
}
