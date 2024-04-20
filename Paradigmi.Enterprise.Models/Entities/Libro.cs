using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Enterprise.Models.Entities
{
	public class Libro
	{
		public int IdLibro { get; set; }
		public string Nome { get; set; }
		public string Autore { get; set; }
		public DateTime DataPubblicazione { get; set; }
		public string Editore { get; set; }

		public virtual ICollection<LibroCategoria> Categorie { get; set; }
	}
}
