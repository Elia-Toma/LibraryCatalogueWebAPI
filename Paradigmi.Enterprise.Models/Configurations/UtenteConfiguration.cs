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
	 * Mapping della classe Utente per il DB
	 */
	public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
	{
		public void Configure(EntityTypeBuilder<Utente> builder)
		{
			builder.ToTable("Utenti");
			builder.HasKey(u => u.IdUtente);
			builder.Property(u => u.Email).HasMaxLength(50).IsRequired();
			builder.Property(u => u.Nome).HasMaxLength(50).IsRequired();
			builder.Property(u => u.Cognome).HasMaxLength(50).IsRequired();
			builder.Property(u => u.Password).HasMaxLength(50).IsRequired();
		}
	}
}
