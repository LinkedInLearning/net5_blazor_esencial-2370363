using Microsoft.AspNetCore.Components;

using StoriesLibrary.Client.Config;
using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Components
{
	public partial class StoriesTable
	{

		private List<string> recentSearches = new List<string> { "terror", "dientes", "gato", "perro", "comedia" };

		private string searchField;

		private string textToFilter;

		private List<Story> filteredResults;

		private string captionWithFilter => Caption + (!string.IsNullOrWhiteSpace(textToFilter) ? $". Filtrando por el texto \"{textToFilter}." : "");
		[Inject]
		private PaginationConfig paginationConfig { get; set; }


		[Parameter]
		public List<Story> Stories { get; set; }

		[Parameter]
		public string Caption { get; set; }

		protected override void OnParametersSet()
		{
			filteredResults = Stories;
		}

		private void PerformSearch()
		{
			textToFilter = searchField;
			if (string.IsNullOrWhiteSpace(textToFilter))
			{
				filteredResults = Stories;
			}
			else
			{
				filteredResults = Stories.Where(s => s.Title.Contains(textToFilter, StringComparison.InvariantCultureIgnoreCase)
					|| s.Author.Contains(textToFilter, StringComparison.InvariantCultureIgnoreCase)
					|| s.Category.Contains(textToFilter, StringComparison.InvariantCultureIgnoreCase)).ToList();
			}
		}

		private void SetRecentSearch(string text)
		{
			searchField = text;
		}
	}
}
