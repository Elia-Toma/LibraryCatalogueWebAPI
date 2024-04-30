using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Enterprise.Models.Context;
using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Models.Repositories
{
	public class TokenRepository
	{
		private MyDbContext _ctx;

		public TokenRepository(MyDbContext ctx)
		{
			_ctx = ctx;
		}

		public Utente getUtenteDaDB(string email, string password)
		{
			return _ctx.Utenti
				.Where(u => u.Email == email && u.Password == password)
				.FirstOrDefault();
		}
	}
}
