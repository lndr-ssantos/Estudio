using Estudio.EntityConfiguracao;
using Estudio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.Data {
	public class EstudioContext : DbContext {
		public EstudioContext (DbContextOptions<EstudioContext> options) : base(options) {}

		public DbSet<Banda> Banda { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			// Atribuir configurações
			modelBuilder.ApplyConfiguration(new BandaConfiguracao());
		}
	}
}
