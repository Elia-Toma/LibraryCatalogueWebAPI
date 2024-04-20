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
	 * Mapping della classe Libro per il DB
	 */
	public class LibroConfiguration : IEntityTypeConfiguration<Libro>
	{
		public void Configure(EntityTypeBuilder<Libro> builder)
		{
			builder.ToTable("Libri");
			builder.HasKey(p=>p.IdLibro);
			builder.Property(p=>p.Nome).HasMaxLength(50).IsRequired();
			builder.Property(p=>p.Autore).HasMaxLength(50).IsRequired();
			builder.Property(p=>p.Editore).HasMaxLength(50).IsRequired();
			builder.Property(p => p.DataPubblicazione).HasColumnType("date").IsRequired();
			builder.HasMany(p => p.Categorie);
		}
	}
}
