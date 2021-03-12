using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Extensions
{
	public static class MultipartFormDataContentExtensions
	{

		public static void AddDictionaryValues(this MultipartFormDataContent formDataContent, Dictionary<string, string> dictionary)
		{
			foreach (var pair in dictionary)
			{
				formDataContent.Add(new StringContent(pair.Value), pair.Key);
			}
		}
	}
}
