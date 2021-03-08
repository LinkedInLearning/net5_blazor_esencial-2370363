using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesLibrary.Shared
{
	public class Story
	{

		public int Id { get; set; }

		public string Title { get; set; }

		public string Author { get; set; }

		public DateTime PublishedDate { get; set; }

		public string Category { get; set; }

		public string Text { get; set; }

	}
}
