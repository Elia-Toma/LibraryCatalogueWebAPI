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
	internal class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
	{
		public void Configure(EntityTypeBuilder<Categoria> builder)
		{
			builder.ToTable("Categorie");
			builder.HasKey(c => c.IdCategoria);
			builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
		}
	}
}