using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Components
{
	public partial class StoryConcurrentChanges
	{

		[Parameter]
		public PropertyValues Value { get; set; }

		private Dictionary<string, string> propertiesToPrint = new Dictionary<string, string> {
			{ "Title", "Título" },
			{ "Author", "Autor" },
			{ "Category", "Categoría" },
			{ "Text", "Texto" }
		};

	}
}
