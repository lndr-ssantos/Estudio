using Estudio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.EntityConfiguracao {
	public class ControleConsumiveisConfiguracao : IEntityTypeConfiguration<ControleConsumiveis> {
		public void Configure(EntityTypeBuilder<ControleConsumiveis> builder) {
			builder.ToTable("CONTROLE_CONSUMIVEIS");

			builder.HasKey(t => t.IdControle);

			builder.HasOne<Agendamento>(t => t.Agendamento)
				.WithMany(a => a.ControleConsumiveis)
				.HasForeignKey(t => t.IdAgendamento);

			builder.HasOne<Consumivel>(t => t.Consumivel)
				.WithMany(c => c.ControleConsumiveis)
				.HasForeignKey(t => t.IdConsumivel);

			builder.Property(t => t.IdControle).HasColumnName("ID_CONTROLE_CONSUMIVEIS").ValueGeneratedOnAdd();
			builder.Property(t => t.IdAgendamento).HasColumnName("ID_AGENDAMENTO").IsRequired();
			builder.Property(t => t.IdConsumivel).HasColumnName("ID_CONSUMIVEL").IsRequired();
			builder.Property(t => t.Quantidade).HasColumnName("QTD_CONSUMIVEL").IsRequired();
		}
	}
}
