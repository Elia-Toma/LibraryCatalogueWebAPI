using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Enterprise.Models.Entities
{
	public class LibroCategoria
	{
		public int IdLibro { get; set; }
		public Libro Libro { get; set; }

		public int IdCategoria { get; set; }
		public Categoria Categoria { get; set; }
	}

}
