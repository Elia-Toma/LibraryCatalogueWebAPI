using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Models.Configurations
{
	/*
	 * Mapping della classe LibroCategoria per il DB
	 */
	public class LibroCategoriaConfiguration : IEntityTypeConfiguration<LibroCategoria>
	{
		public void Configure(EntityTypeBuilder<LibroCategoria> builder)
		{
			builder.ToTable("LibriCategorie");
			builder.HasKey(p=>new {p.IdLibro, p.IdCategoria});
			builder.HasOne(p => p.Libro).WithMany(p => p.Categorie).HasForeignKey(p => p.IdLibro);
			builder.HasOne(p => p.Categoria).WithMany(p => p.Libri).HasForeignKey(p => p.IdCategoria);
		}
	}
}
