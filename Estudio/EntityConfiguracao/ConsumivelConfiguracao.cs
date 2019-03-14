using Estudio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.EntityConfiguracao {
	public class ConsumivelConfiguracao : IEntityTypeConfiguration<Consumivel> {
		public void Configure(EntityTypeBuilder<Consumivel> builder) {
			builder.ToTable("CONSUMIVEIS");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id).HasColumnName("ID_CONSUMIVEL").ValueGeneratedOnAdd();
			builder.Property(t => t.Nome).HasColumnName("NOME_CONSUMIVEL").IsRequired();
			builder.Property(t => t.Tipo).HasColumnName("TIPO_CONSUMIVEL").IsRequired();
			builder.Property(t => t.Valor).HasColumnName("VALOR_CONSUMIVEL").IsRequired();
		}
	}
}
