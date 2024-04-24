using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Application.Models.Dtos
{
	public class LibroDto
	{
		public LibroDto()
		{
		}

		public LibroDto(Libro libro)
		{
			Id = libro.IdLibro;
			Nome = libro.Nome;
			Autore = libro.Autore;
			DataPubblicazione = libro.DataPubblicazione;
			Editore = libro.Editore;

			// Non so se questa va bene
			Categorie = libro.Categorie;
		}

		public int Id { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string Autore { get; set; } = string.Empty;
		public DateTime DataPubblicazione { get; set; }
		public string Editore { get; set; } = string.Empty;

		// Non so se questa va bene
		public virtual ICollection<LibroCategoria> Categorie { get; set; }
	}
}
