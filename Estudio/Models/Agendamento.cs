using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.Models {
	public class Agendamento {
		public int IdAgendamento { get; set; }
		public int IdBanda { get; set; }
		public Banda Banda { get; set; }
		public int IdSala { get; set; }
		public Sala Sala { get; set; }
		public int? IdFuncionario { get; set; }
		public Funcionario Funcionario { get; set; }
		public decimal? Valor { get; set; }
		public bool Ativo { get; set; }
		public DateTime Data { get; set; }
		public IList<ControleConsumiveis> ControleConsumiveis { get; set; }

		public Agendamento() {
			Ativo = true; 
		}
	}
}
