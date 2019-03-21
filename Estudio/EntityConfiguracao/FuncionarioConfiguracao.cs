using Estudio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.EntityConfiguracao {
	public class FuncionarioConfiguracao : IEntityTypeConfiguration<Funcionario> {
		public void Configure(EntityTypeBuilder<Funcionario> builder) {
			builder.ToTable("FUNCIONARIOS");

			builder.HasKey(t => t.IdFuncionario);

			builder.Property(t => t.IdFuncionario).HasColumnName("ID_FUNCIONARIO").ValueGeneratedOnAdd();
			builder.Property(t => t.Nome).HasColumnName("NOME_FUNCIONARIO").IsRequired();
			builder.Property(t => t.Email).HasColumnName("EMAIL_FUNCIONARIO").IsRequired();
			builder.Property(t => t.Senha).HasColumnName("SENHA_FUNCIONARIO").IsRequired();
		}
	}
}
