using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using StoriesLibrary.Entities;

using System;

namespace StoriesLibrary.Data
{
	public class StoriesContext : DbContext
	{

		public DbSet<Story> Stories { get; set; }

		public StoriesContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			var s = modelBuilder.Entity<Story>();
			s.HasKey(p => p.Id);
			s.Property(p => p.Title).IsRequired().HasMaxLength(100);
			s.Property(p => p.Author).IsRequired().HasMaxLength(250);
			s.Property(p => p.Category).IsRequired().HasMaxLength(50);
			s.Property(p => p.Text).IsRequired();
			s.Property(p => p.Text).IsConcurrencyToken();
			SeedStories(s);
		}

		private void SeedStories(EntityTypeBuilder<Story> entity)
		{
			entity.HasData(
				new Story { Id = 1, Title = "Los ángulos tienen dientes", Author = "Eva Artés", PublishedDate = new DateTime(2021, 2, 28, 13, 22, 51), Category = "terror", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 2, Title = "La gasolinera", Author = "Raquel Sastre", PublishedDate = new DateTime(2021, 2, 28, 14, 22, 51), Category = "novela", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 3, Title = "Dejad que los niños se acerquen a mí", Author = "Andrés López", PublishedDate = new DateTime(2021, 2, 28, 15, 22, 51), Category = "terror", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 4, Title = "El vuelo al fin del mundo", Author = "Lucía Castillo", PublishedDate = new DateTime(2021, 2, 28, 16, 22, 51), Category = "ciencia ficción", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 5, Title = "El tocador de la abuela", Author = "Diego de Salazar", PublishedDate = new DateTime(2021, 2, 28, 17, 22, 51), Category = "novela", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 6, Title = "Las cerillas mojadas no sirven para nada", Author = "Daniela Rubio", PublishedDate = new DateTime(2021, 2, 28, 18, 22, 51), Category = "novela", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 7, Title = "Sacando las castañas del fuego", Author = "Ricardo Allen", PublishedDate = new DateTime(2021, 2, 28, 19, 22, 51), Category = "ciencia ficción", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 8, Title = "Los árboles invisibles", Author = "Núria Azanza", PublishedDate = new DateTime(2021, 2, 28, 20, 22, 51), Category = "novela histórica", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 9, Title = "Dirección prohibida", Author = "Blanca Romero", PublishedDate = new DateTime(2021, 2, 28, 21, 22, 51), Category = "novela", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 10, Title = "El olor de las margaritas", Author = "Alfonso Tirado", PublishedDate = new DateTime(2021, 2, 28, 22, 22, 51), Category = "romántica", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 11, Title = "Planetas sin vida", Author = "Alejandro Carbonell", PublishedDate = new DateTime(2021, 2, 28, 23, 22, 51), Category = "ciencia ficción", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 12, Title = "La vacuna", Author = "Ignacio Aguado", PublishedDate = new DateTime(2021, 2, 28, 0, 22, 51), Category = "ciencia ficción", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 13, Title = "El master", Author = "Cristóbal Lafuente", PublishedDate = new DateTime(2021, 2, 28, 1, 22, 51), Category = "Thriller", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 14, Title = "El desorden de tu ausencia", Author = "Eduardo Préscoli", PublishedDate = new DateTime(2021, 2, 28, 2, 22, 51), Category = "romántica", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 15, Title = "Los amigos que fuimos", Author = "Gloria Onrubia", PublishedDate = new DateTime(2021, 2, 28, 3, 22, 51), Category = "ciencia ficción", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 16, Title = "Saltando charcos", Author = "Elena Carrión", PublishedDate = new DateTime(2021, 2, 28, 4, 22, 51), Category = "ciencia ficción", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 17, Title = "Las garras del hambre", Author = "Jesús Palomo", PublishedDate = new DateTime(2021, 2, 28, 5, 22, 51), Category = "literatura", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 18, Title = "El barco de papel", Author = "Daniel Martín", PublishedDate = new DateTime(2021, 2, 28, 5, 22, 51), Category = "Thriller", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 19, Title = "Los gatos también ladran", Author = "Rosa Ramos", PublishedDate = new DateTime(2021, 2, 28, 6, 22, 51), Category = "ciencia ficción", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 20, Title = "Durmiendo", Author = "Roberto Masip", PublishedDate = new DateTime(2021, 2, 28, 7, 22, 51), Category = "novela", Text = $"Línea 1{Environment.NewLine}Línea 2" },
				new Story { Id = 21, Title = "La mirada vacía", Author = "Juan María Martín", PublishedDate = new DateTime(2021, 2, 28, 8, 22, 51), Category = "ciencia ficción", Text = $"Línea 1{Environment.NewLine}Línea 2" }
				);
		}
	}
}
