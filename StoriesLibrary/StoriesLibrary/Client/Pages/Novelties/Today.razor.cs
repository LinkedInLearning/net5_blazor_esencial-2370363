using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

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

		[Inject]
		private ILogger<Today> logger { get; set; }

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
			_stories = await GetStoriesAsync();
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

		private async Task<List<Story>> GetStoriesAsync()
		{
			await Task.Delay(2000);
			return new List<Story>
			{
				new Story { Title = "Los ángulos tienen dientes", Author = "Eva Artés", PublishedDate = new DateTime(2021, 2, 28, 13, 22, 51), Category = "terror" },
				new Story { Title = "La gasolinera", Author = "Raquel Sastre", PublishedDate = new DateTime(2021, 2, 28, 14, 22, 51), Category = "novela" },
				new Story { Title = "Dejad que los niños se acerquen a mí", Author = "Andrés López", PublishedDate = new DateTime(2021, 2, 28, 15, 22, 51), Category = "terror" },
				new Story { Title = "El vuelo al fin del mundo", Author = "Lucía Castillo", PublishedDate = new DateTime(2021, 2, 28, 16, 22, 51), Category = "ciencia ficción" },
				new Story { Title = "El tocador de la abuela", Author = "Diego de Salazar", PublishedDate = new DateTime(2021, 2, 28, 17, 22, 51), Category = "novela" },
				new Story { Title = "Las cerillas mojadas no sirven para nada", Author = "Daniela Rubio", PublishedDate = new DateTime(2021, 2, 28, 18, 22, 51), Category = "novela" },
				new Story { Title = "Sacando las castañas del fuego", Author = "Ricardo Allen", PublishedDate = new DateTime(2021, 2, 28, 19, 22, 51), Category = "ciencia ficción" },
				new Story { Title = "Los árboles invisibles", Author = "Núria Azanza", PublishedDate = new DateTime(2021, 2, 28, 20, 22, 51), Category = "novela histórica" },
				new Story { Title = "Dirección prohibida", Author = "Blanca Romero", PublishedDate = new DateTime(2021, 2, 28, 21, 22, 51), Category = "novela" },
				new Story { Title = "El olor de las margaritas", Author = "Alfonso Tirado", PublishedDate = new DateTime(2021, 2, 28, 22, 22, 51), Category = "romántica" },
				new Story { Title = "Planetas sin vida", Author = "Alejandro Carbonell", PublishedDate = new DateTime(2021, 2, 28, 23, 22, 51), Category = "ciencia ficción" },
				new Story { Title = "La vacuna", Author = "Ignacio Aguado", PublishedDate = new DateTime(2021, 2, 28, 0, 22, 51), Category = "ciencia ficción" },
				new Story { Title = "El master", Author = "Cristóbal Lafuente", PublishedDate = new DateTime(2021, 2, 28, 1, 22, 51), Category = "Thriller" },
				new Story { Title = "El desorden de tu ausencia", Author = "Eduardo Préscoli", PublishedDate = new DateTime(2021, 2, 28, 2, 22, 51), Category = "romántica" },
				new Story { Title = "Los amigos que fuimos", Author = "Gloria Onrubia", PublishedDate = new DateTime(2021, 2, 28, 3, 22, 51), Category = "ciencia ficción" },
				new Story { Title = "Saltando charcos", Author = "Elena Carrión", PublishedDate = new DateTime(2021, 2, 28, 4, 22, 51), Category = "ciencia ficción" },
				new Story { Title = "Las garras del hambre", Author = "Jesús Palomo", PublishedDate = new DateTime(2021, 2, 28, 5, 22, 51), Category = "literatura" },
				new Story { Title = "El barco de papel", Author = "Daniel Martín", PublishedDate = new DateTime(2021, 2, 28, 5, 22, 51), Category = "Thriller" },
				new Story { Title = "Los gatos también ladran", Author = "Rosa Ramos", PublishedDate = new DateTime(2021, 2, 28, 6, 22, 51), Category = "ciencia ficción" },
				new Story { Title = "Durmiendo", Author = "Roberto Masip", PublishedDate = new DateTime(2021, 2, 28, 7, 22, 51), Category = "novela" },
				new Story { Title = "La mirada vacía", Author = "Juan María Martín", PublishedDate = new DateTime(2021, 2, 28, 8, 22, 51), Category = "ciencia ficción" }
			};
		}
	}
}
