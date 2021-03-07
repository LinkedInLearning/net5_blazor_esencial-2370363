using Microsoft.AspNetCore.Components;

using StoriesLibrary.Client.Entities;

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

		private int percentage;

		[Parameter]
		public FormMode Mode { get; set; }

		private void FillingPercentageChanged(FillingPercentageChangedEventArgs e)
		{
			percentage = e.FillingPercentage;
		}
	}
}
