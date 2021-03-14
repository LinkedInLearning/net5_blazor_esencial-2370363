using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Pages.Admin.Stories
{
	public partial class Edit
	{

		[Parameter]
		public int? StoryId { get; set; }

	}
}
