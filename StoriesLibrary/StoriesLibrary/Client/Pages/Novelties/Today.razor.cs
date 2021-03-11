using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using StoriesLibrary.Client.Services;
using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Pages.Novelties
{
	public partial class Today
	{
		private List<Story> _stories;

		private bool errorsWhenLoading = false;

		private Story selectedStory;

		[Inject]
		private ILogger<Today> logger { get; set; }

		[Inject]
		private IStoriesService storiesService { get; set; }

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
				_stories = await storiesService.GetNoveltiesAsync(StoriesService.NoveltiesScope.Today);
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
			selectedStory = story;
		}
	}
}
