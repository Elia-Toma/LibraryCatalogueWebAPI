using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Enterprise.Models.Context;
using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Models.Repositories
{
	public class CategoriaRepository : GenericRepository<Categoria>
	{
		public CategoriaRepository(MyDbContext ctx) : base(ctx)
		{
		}

		public void CreateCategoria(Categoria categoria)
		{
			if (_ctx.Categorie.Any(c => c.Nome == categoria.Nome))
			{
				throw new InvalidOperationException("Categoria già esistente");
			}
			Aggiungi(categoria);
		}

		public void DeleteCategoriaVuota(int id)
		{
			if (_ctx.LibriCategorie.Any(l => l.IdCategoria == id))
			{
				throw new InvalidOperationException("Categoria non vuota");
			}
			Elimina(id);
		}
	}
}
