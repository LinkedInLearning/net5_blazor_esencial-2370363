using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Pages.Stories
{
	public partial class AddOrEdit
	{

		public enum FormMode
		{
			Add,
			Edit
		}

		[Parameter]
		public FormMode Mode { get; set; }

	}
}
