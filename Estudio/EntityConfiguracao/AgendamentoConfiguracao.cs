using Estudio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.EntityConfiguracao {
	public class AgendamentoConfiguracao : IEntityTypeConfiguration<Agendamento> {
		public void Configure(EntityTypeBuilder<Agendamento> builder) {
			//Tabela a ser mapeada
			builder.ToTable("AGENDAMENTOS");

			//Chave primária
			builder.HasKey(t => t.IdAgendamento);

			//Chaves estrangeiras
			builder.HasOne<Banda>(t => t.Banda)
				.WithMany(b => b.Agendamentos)
				.HasForeignKey(t => t.IdBanda);

			builder.HasOne<Funcionario>(t => t.Funcionario)
				.WithMany(f => f.Agendamentos)
				.HasForeignKey(t => t.IdFuncionario);

			builder.HasOne<Sala>(t => t.Sala)
				.WithMany(s => s.Agendamentos)
				.HasForeignKey(t => t.IdSala);

			// Mapeando propriedades da classe com as respectivas colunas que representam
			builder.Property(t => t.IdAgendamento).HasColumnName("ID_AGENDAMENTO").ValueGeneratedOnAdd();
			builder.Property(t => t.IdBanda).HasColumnName("ID_BANDA").IsRequired();
			builder.Property(t => t.IdSala).HasColumnName("ID_SALA").IsRequired();
			builder.Property(t => t.IdFuncionario).HasColumnName("ID_FUNCIONARIO");
			builder.Property(t => t.Valor).HasColumnName("VALOR");
			builder.Property(t => t.Status).HasColumnName("STATUS").IsRequired();
			builder.Property(t => t.Data).HasColumnName("DATA").IsRequired();
		}
	}
}
