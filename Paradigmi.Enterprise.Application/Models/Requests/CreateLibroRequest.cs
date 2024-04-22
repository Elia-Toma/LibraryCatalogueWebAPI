using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Application.Models.Requests
{
	public class CreateLibroRequest
	{
		public string Nome { get; set; } = string.Empty;
		public string Autore { get; set; } = string.Empty;
		//public DateTime DataPubblicazione { get; set; }
		public string Editore { get; set; } = string.Empty;

		//public virtual ICollection<LibroCategoria> Categorie { get; set; }

		public Libro ToEntity()
		{
			return new Libro
			{
				Nome = Nome,
				Autore = Autore,
				//DataPubblicazione = DataPubblicazione,
				Editore = Editore
			};
		}
	}
}
