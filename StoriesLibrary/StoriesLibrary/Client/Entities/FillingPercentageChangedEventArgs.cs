using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Entities
{
	public class FillingPercentageChangedEventArgs : EventArgs
	{

		public int Length { get; set; }

		public int FillingPercentage { get; set; }
	}
}
