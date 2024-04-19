using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Models.Context
{
	public class MyDbContext : DbContext
	{
		public DbSet<Libro> Libri { get; set; }
		public DbSet<Utente> Utenti { get; set; }
		public DbSet<Categoria> Categorie { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer("data source=localhost;Initial catalog=ProgettoEnterprise;User Id=enterprise;Password=enterprise;TrustServerCertificate=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Carica le configurazioni dalle classi in questo progetto che implementano IEntityTypeConfiguration

			modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
