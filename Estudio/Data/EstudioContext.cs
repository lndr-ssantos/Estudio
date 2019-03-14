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

		public DbSet<Banda> Bandas { get; set; }
		public DbSet<Agendamento> Agendamentos { get; set; }
		public DbSet<Funcionario> Funcionarios { get; set; }
		public DbSet<Sala> Salas { get; set; }
		public DbSet<Consumivel> Consumiveis { get; set; }
		public DbSet<ControleConsumiveis> ControleConsumiveis { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			// Atribuir configurações
			modelBuilder.ApplyConfiguration(new BandaConfiguracao());
			modelBuilder.ApplyConfiguration(new AgendamentoConfiguracao());
			modelBuilder.ApplyConfiguration(new FuncionarioConfiguracao());
			modelBuilder.ApplyConfiguration(new SalaConfiguracao());
			modelBuilder.ApplyConfiguration(new ConsumivelConfiguracao());
			modelBuilder.ApplyConfiguration(new ControleConsumiveisConfiguracao());
		}
	}
}
