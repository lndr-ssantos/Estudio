using Estudio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.EntityConfiguracao {
	public class InstrumentoConfiguracao : IEntityTypeConfiguration<Instrumento> {
		public void Configure(EntityTypeBuilder<Instrumento> builder) {
			builder.ToTable("INSTRUMENTOS");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id).HasColumnName("ID_INSTRUMENTO").ValueGeneratedOnAdd();
			builder.Property(t => t.Modelo).HasColumnName("MODELO").IsRequired();
			builder.Property(t => t.Marca).HasColumnName("MARCA").IsRequired();
			builder.Property(t => t.Tipo).HasColumnName("TIPO").IsRequired();
		}
	}
}
