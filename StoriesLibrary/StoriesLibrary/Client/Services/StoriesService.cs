using StoriesLibrary.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Services
{
	public class StoriesService : IStoriesService
	{
		public enum NoveltiesScope
		{
			Today,
			Week,
			Month
		}

		private List<Story> stories;

		public StoriesService()
		{
			stories = new List<Story>
			{
				new Story {  Id = 1, Title = "Los ángulos tienen dientes", Author = "Eva Artés", PublishedDate = new DateTime(2021, 2, 28, 13, 22, 51), Category = "terror", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 2, Title = "La gasolinera", Author = "Raquel Sastre", PublishedDate = new DateTime(2021, 2, 28, 14, 22, 51), Category = "novela", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 3, Title = "Dejad que los niños se acerquen a mí", Author = "Andrés López", PublishedDate = new DateTime(2021, 2, 28, 15, 22, 51), Category = "terror", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 4, Title = "El vuelo al fin del mundo", Author = "Lucía Castillo", PublishedDate = new DateTime(2021, 2, 28, 16, 22, 51), Category = "ciencia ficción", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id= 5, Title = "El tocador de la abuela", Author = "Diego de Salazar", PublishedDate = new DateTime(2021, 2, 28, 17, 22, 51), Category = "novela" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 6, Title = "Las cerillas mojadas no sirven para nada", Author = "Daniela Rubio", PublishedDate = new DateTime(2021, 2, 28, 18, 22, 51), Category = "novela" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 7, Title = "Sacando las castañas del fuego", Author = "Ricardo Allen", PublishedDate = new DateTime(2021, 2, 28, 19, 22, 51), Category = "ciencia ficción" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 8, Title = "Los árboles invisibles", Author = "Núria Azanza", PublishedDate = new DateTime(2021, 2, 28, 20, 22, 51), Category = "novela histórica" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 9, Title = "Dirección prohibida", Author = "Blanca Romero", PublishedDate = new DateTime(2021, 2, 28, 21, 22, 51), Category = "novela" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 10, Title = "El olor de las margaritas", Author = "Alfonso Tirado", PublishedDate = new DateTime(2021, 2, 28, 22, 22, 51), Category = "romántica" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 11, Title = "Planetas sin vida", Author = "Alejandro Carbonell", PublishedDate = new DateTime(2021, 2, 28, 23, 22, 51), Category = "ciencia ficción" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 12, Title = "La vacuna", Author = "Ignacio Aguado", PublishedDate = new DateTime(2021, 2, 28, 0, 22, 51), Category = "ciencia ficción" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 13, Title = "El master", Author = "Cristóbal Lafuente", PublishedDate = new DateTime(2021, 2, 28, 1, 22, 51), Category = "Thriller" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 14, Title = "El desorden de tu ausencia", Author = "Eduardo Préscoli", PublishedDate = new DateTime(2021, 2, 28, 2, 22, 51), Category = "romántica" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 15, Title = "Los amigos que fuimos", Author = "Gloria Onrubia", PublishedDate = new DateTime(2021, 2, 28, 3, 22, 51), Category = "ciencia ficción" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 16, Title = "Saltando charcos", Author = "Elena Carrión", PublishedDate = new DateTime(2021, 2, 28, 4, 22, 51), Category = "ciencia ficción" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 17, Title = "Las garras del hambre", Author = "Jesús Palomo", PublishedDate = new DateTime(2021, 2, 28, 5, 22, 51), Category = "literatura" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 18, Title = "El barco de papel", Author = "Daniel Martín", PublishedDate = new DateTime(2021, 2, 28, 5, 22, 51), Category = "Thriller" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 19, Title = "Los gatos también ladran", Author = "Rosa Ramos", PublishedDate = new DateTime(2021, 2, 28, 6, 22, 51), Category = "ciencia ficción" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 20, Title = "Durmiendo", Author = "Roberto Masip", PublishedDate = new DateTime(2021, 2, 28, 7, 22, 51), Category = "novela" , Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 21, Title = "La mirada vacía", Author = "Juan María Martín", PublishedDate = new DateTime(2021, 2, 28, 8, 22, 51), Category = "ciencia ficción", Text = $"Línea 1{Environment.NewLine}Línea 2" }
			}.OrderByDescending(s => s.PublishedDate).ToList();
		}

		public List<Story> GetNovelties(NoveltiesScope scope)
		{
			return stories;
		}

		public List<Story> GetAll()
		{
			var inventedStories = stories.ToList();
			var words = stories.SelectMany(s => s.Title.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(w => w.Trim(new[] { ',', '.' }))).Distinct();
			var authorNames = stories.Select(s => s.Author.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim(new[] { ',', '.' }));
			var authorLastNames = stories.SelectMany(s => s.Author.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1..].Select(w => w.Trim(new[] { ',', '.' }))).Where(w => !new[] { "de", "la" }.Contains(w)).Distinct();
			int initialRange = stories.Count + 1, finalRange = 300;
			foreach (var i in Enumerable.Range(initialRange, finalRange))
			{
				inventedStories.Add(GenerateStory(i, words, authorNames, authorLastNames));
			}
			return inventedStories.OrderByDescending(s => s.PublishedDate).ToList();
		}

		private Story GenerateStory(int storyId, IEnumerable<string> words, IEnumerable<string> authorNames, IEnumerable<string> authorLastNames)
		{
			var wordsCopy = words.ToList();
			var authorNamesCopy = authorNames.ToList();
			var authorLastNamesCopy = authorLastNames.ToList();
			int minWordsInTitle = 3, maxWordsInTitle = 10;
			var rnd = new Random();
			var wordsInTitle = rnd.Next(minWordsInTitle, maxWordsInTitle + 1);
			var randomTitle = new List<string>();

			for (var i = 0; i < wordsInTitle; i++)
			{
				var word = ExtractRandomWord(wordsCopy);
				randomTitle.Add(word);
			}

			var randomAuthor = new List<string>();
			randomAuthor.Add(ExtractRandomWord(authorNamesCopy));
			randomAuthor.Add(ExtractRandomWord(authorLastNamesCopy));
			randomAuthor.Add(ExtractRandomWord(authorLastNamesCopy));
			return new Story {
				Id = storyId,
				Title = string.Join(" ", randomTitle),
				Author = string.Join(" ", randomAuthor),
				Category = "random",
				PublishedDate = new DateTime(2021, rnd.Next(1, 13), rnd.Next(1, 29), rnd.Next(0, 24), rnd.Next(0, 60), 0)
			};
		}

		private static string ExtractRandomWord(List<string> wordList)
		{
			var rnd = new Random();
			var index = rnd.Next(0, wordList.Count);
			var word = wordList[index];
			wordList.RemoveAt(index);
			return word;
		}
	}
}