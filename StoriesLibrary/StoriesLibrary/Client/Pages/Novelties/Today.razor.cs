using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using StoriesLibrary.Client.Services;
using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Pages.Novelties
{
	public partial class Today
	{
		private List<Story> _stories;

		private bool errorsWhenLoading = false;

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
			logger.LogInformation("Se ha llamado a OnInitializedAsync. El componente se acaba de iniciar.");
			try
			{
				_stories = storiesService.GetNovelties(StoriesService.NoveltiesScope.Today);
			}
			catch (Exception ex)
			{
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
	}
}
