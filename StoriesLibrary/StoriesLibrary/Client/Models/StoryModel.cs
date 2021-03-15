using Microsoft.AspNetCore.Components.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesLibrary.Client.Models
{
	public class StoryModel
	{
		public enum CommentsType
		{
			None,
			OnlyRegistered,
			All
		}

		[Required(ErrorMessage = "El título de la historia es obligatorio.")]
		[MaxLength(100, ErrorMessage = "El tamaño máximo del título es de cien caracteres.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "La categoría de la historia es obligatoria.")]
		[MaxLength(100, ErrorMessage = "El tamaño máximo de la categoría es de cien caracteres.")]
		public string Category { get; set; }

		[Required(ErrorMessage = "El texto de la historia es obligatorio, si no, ¿qué clase de historia sería? ;)")]
		public string Text { get; set; }

		public IBrowserFile Mp3File { get; set; }


		public CommentsType Comments { get; set; } = CommentsType.None;

		public bool AllowRatting { get; set; } = true;

		[Range(typeof(bool), "true", "true", ErrorMessage = "Debes aceptar la política de privacidad.")]
		public bool AcceptPrivacyPolicy { get; set; }

	}
}
