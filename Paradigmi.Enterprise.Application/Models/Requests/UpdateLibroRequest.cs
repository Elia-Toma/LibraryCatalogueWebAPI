using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Application.Models.Requests
{
	public class UpdateLibroRequest
	{
		public int IdLibro { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string Autore { get; set; } = string.Empty;
		public DateTime DataPubblicazione { get; set; }
		public string Editore { get; set; } = string.Empty;

		public Libro ToEntity()
		{
			var libro = new Libro
			{
				Nome = Nome,
				Autore = Autore,
				DataPubblicazione = DataPubblicazione,
				Editore = Editore,
				Categorie = new List<LibroCategoria>()
			};

			return libro;
		}
	}
}
