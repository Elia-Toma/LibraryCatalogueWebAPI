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
	}
}
