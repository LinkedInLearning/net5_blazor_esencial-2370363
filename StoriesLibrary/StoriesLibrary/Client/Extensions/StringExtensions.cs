using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Extensions
{
	public static class StringExtensions
	{

		public static string ConvertToHtml(this string str)
		{
			if (str is null)
			{
				throw new ArgumentNullException(nameof(str));
			}

			return $"<p>{str.Replace("\n", "</p>" + Environment.NewLine + "<p>").Replace("\r", string.Empty)}</p>";
		}
	}
}