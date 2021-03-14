﻿using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Pages
{
	public partial class Index
	{

		[CascadingParameter(Name = "numberOfSubscribers")]
		private int numberOfStories { get; set; }

	}
}
