using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Enterprise.Models.Context;
using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Models.Repositories
{
	public class LibroRepository : GenericRepository<Libro>
	{
		public LibroRepository(MyDbContext ctx) : base(ctx)
		{
		}

		public void DeleteLibro(int id)
		{
			DeleteCategorieAssociateAlLibro(id);
			Elimina(id);
		}

		private void DeleteCategorieAssociateAlLibro(int id)
		{
			_ctx.LibriCategorie.RemoveRange(_ctx.LibriCategorie.Where(lc => lc.IdLibro == id));
		}

		public Libro GetLibroDaNome(string nome)
		{
			return _ctx.Libri.First(l => l.Nome == nome);
		}

		public List<Libro> GetLibriDaAutore(string autore)
		{
			return _ctx.Libri.Where(l => l.Autore == autore).ToList();
		}
	}
}
