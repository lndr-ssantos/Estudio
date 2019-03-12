using Estudio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.EntityConfiguracao {
	public class BandaConfiguracao : IEntityTypeConfiguration<Banda> {
		public void Configure(EntityTypeBuilder<Banda> builder) {
			// Tabela ser mapeada
			builder.ToTable("BANDAS");

			// Mapeando a propriedade da classe que representa a chave primária
			builder.HasKey(t => t.IdBanda);

			// Mapeando propriedades da classe com as respectivas colunas que representam
			builder.Property(t => t.IdBanda).HasColumnName("ID_BANDA").ValueGeneratedOnAdd();
			builder.Property(t => t.NomeBanda).HasColumnName("NOME_BANDA").IsRequired();
			builder.Property(t => t.QtdIntegrantes).HasColumnName("QTD_INTEGRANTES").IsRequired();
			builder.Property(t => t.NomeResponsavel).HasColumnName("NOME_RESPONSAVEL").IsRequired();
			builder.Property(t => t.TelResponsavel).HasColumnName("TEL_RESPONSAVEL").IsRequired();
			builder.Property(t => t.EmailResponsavel).HasColumnName("EMAIL_RESPONSAVEL").IsRequired();
			builder.Property(t => t.CPFResponsavel).HasColumnName("CPF_RESPONSAVEL").IsRequired();
		}
	}
}
