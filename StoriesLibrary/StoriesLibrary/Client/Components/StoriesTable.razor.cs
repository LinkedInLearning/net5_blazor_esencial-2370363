using Microsoft.AspNetCore.Components;

using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Components
{
	public partial class StoriesTable
	{

		[Parameter]
		public List<Story> Stories { get; set; }

		[Parameter]
		public string Caption { get; set; }

	}
}
