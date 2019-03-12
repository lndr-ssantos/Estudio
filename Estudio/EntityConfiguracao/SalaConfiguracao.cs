using Estudio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.EntityConfiguracao {
	public class SalaConfiguracao : IEntityTypeConfiguration<Sala> {
		public void Configure(EntityTypeBuilder<Sala> builder) {
			builder.ToTable("SALAS");

			builder.HasKey(t => t.IdSala);

			builder.Property(t => t.IdSala).HasColumnName("ID_SALA").ValueGeneratedOnAdd();
			builder.Property(t => t.Nome).HasColumnName("NOME_SALA").IsRequired();
			builder.Property(t => t.Tipo).HasColumnName("TIPO_SALA").IsRequired();
			builder.Property(t => t.Valor).HasColumnName("VALOR_SALA").IsRequired();
		}
	}
}
