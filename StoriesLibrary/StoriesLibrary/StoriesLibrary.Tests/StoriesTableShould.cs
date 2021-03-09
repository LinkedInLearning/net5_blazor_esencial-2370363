using Bunit;
using Bunit.Rendering;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

using Moq;

using StoriesLibrary.Client.Components;
using StoriesLibrary.Client.Config;
using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

namespace StoriesLibrary.Tests
{
	public class StoriesTableShould
	{

		[Fact]
		public void StoriesTableShouldRenderDefaultTableWithSingleRowWhenSingleStoryIsProvided()
		{
			// Arrange
			using var context = new TestContext();
			context.JSInterop.Mode = JSRuntimeMode.Loose;
			var story = new Story
			{
				Title = "Uno dos y tes",
				Author = "El chistoso",
				Category = "tonterías",
				PublishedDate = new DateTime(2021, 3, 9, 12, 13, 14),
				Id = 1,
				Text = "Van dos soldados en una moto y no se caen porque van soldados."
			};
			var paginationConfig = new PaginationConfig { NumberOfResults = 10, PagesVisible = 5 };
			context.Services.AddSingleton(paginationConfig);

			// Act
			var cut = context.RenderComponent<StoriesTable>(
				ComponentParameter.CreateParameter("Stories", new List<Story> { story }),
				ComponentParameter.CreateParameter("Caption", "Tabla de prueba")
				);

			// Assert
			var tableCaption = cut.Find("caption");
			Assert.Equal("Tabla de prueba", tableCaption.TextContent);
			var tableCells = cut.FindAll("tbody td");
			Assert.Equal(4, tableCells.Count);
			Assert.Equal(1, tableCells[0].ChildNodes.Length);
			Assert.Equal("Uno dos y tes", tableCells[0].ChildNodes[0].TextContent);
		}

		[Fact]
		public void StoriesTableShouldRenderCustomHeaderAndRowsWithSingleRowWhenTemplatesAndSingleStoryAreProvided()
		{
			// Arrange
			using var context = new TestContext();
			context.JSInterop.Mode = JSRuntimeMode.Loose;
			var story = new Story
			{
				Title = "Uno dos y tes",
				Author = "El chistoso",
				Category = "tonterías",
				PublishedDate = new DateTime(2021, 3, 9, 12, 13, 14),
				Id = 1,
				Text = "Van dos soldados en una moto y no se caen porque van soldados."
			};
			var paginationConfig = new PaginationConfig { NumberOfResults = 10, PagesVisible = 5 };
			context.Services.AddSingleton(paginationConfig);

			var headerTemplate = new RenderFragment(b =>
			{
				b.AddMarkupContent(1, "<thead><th>Título</th><th>Autor</th><th>Fecha de publicación</th><th>Categoría</th><th>Adicional</th></thead>");
			});

			var rowTemplate = new RenderFragment<(Story Story, StoriesTable Table)>(t =>
			{
				var tempRenderFragment = new RenderFragment(b =>
				{
					b.AddMarkupContent(1, $"<td>{t.Story.Title}</td><td>{t.Story.Author}</td><td>{t.Story.PublishedDate.ToString("dd/MM/yyyy HH:mm")}</td><td>{t.Story.Category}</td><td>Columna adicional</td>");
				});
				return tempRenderFragment;
			});

			// Act
			var cut = context.RenderComponent<StoriesTable>(
				ComponentParameter.CreateParameter("Stories", new List<Story> { story }),
				ComponentParameter.CreateParameter("Caption", "Tabla de prueba"),
				ComponentParameter.CreateParameter("HeaderTemplate", headerTemplate),
				ComponentParameter.CreateParameter("RowTemplate", rowTemplate)
				);

			// Assert
			var tableCaption = cut.Find("caption");
			Assert.Equal("Tabla de prueba", tableCaption.TextContent);
			var tableCells = cut.FindAll("tbody td");
			Assert.Equal(5, tableCells.Count);
			Assert.Equal(1, tableCells[0].ChildNodes.Length);
			Assert.Equal("Uno dos y tes", tableCells[0].ChildNodes[0].TextContent);
			Assert.Equal("Columna adicional", tableCells[4].ChildNodes[0].TextContent);
		}
	}
}
