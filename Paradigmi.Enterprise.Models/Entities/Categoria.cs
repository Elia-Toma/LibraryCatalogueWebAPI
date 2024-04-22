using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Enterprise.Models.Entities
{
	public class Categoria
	{
		public int IdCategoria { get; set; }
		public string Nome { get; set; } = string.Empty;

		// Una categoria può avere più libri, collection necessaria per la relazione molti a molti
		public virtual ICollection<LibroCategoria> Libri { get; set; }
	}
}
