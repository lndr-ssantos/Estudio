using Estudio.EntityConfiguracao;
using Estudio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.Data {
	public class EstudioContext : DbContext {
		public EstudioContext(DbContextOptions<EstudioContext> options) : base(options) { }

		public DbSet<Banda> Banda { get; set; }
		public DbSet<Agendamento> Agendamento { get; set; }
		public DbSet<Funcionario> Funcionario { get; set; }
		public DbSet<Sala> Sala { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			// Atribuir configurações
			modelBuilder.ApplyConfiguration(new BandaConfiguracao());
			modelBuilder.ApplyConfiguration(new AgendamentoConfiguracao());
			modelBuilder.ApplyConfiguration(new FuncionarioConfiguracao());
			modelBuilder.ApplyConfiguration(new SalaConfiguracao());
		}
	}
}
