using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Models.Context
{
	internal class MyDbContext : DbContext
	{
		public DbSet<Libro> Libri { get; set; }
		public DbSet<Utente> Utenti { get; set; }
		public DbSet<Categoria> Categorie { get; set; }
	}
}
