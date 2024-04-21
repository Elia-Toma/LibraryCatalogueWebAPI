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
	}
}
