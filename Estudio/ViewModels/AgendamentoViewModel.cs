using Estudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.ViewModels {
	public class AgendamentoViewModel {
		public int IdAgendamento { get; set; }
		public string NomeBanda { get; set; }
		public string NomeSala { get; set; }
		public List<ControleConsumiveis> Consumiveis { get; set; }
		public decimal AgendamentoValor { get; set; }
		public string Data { get; set; }
	}
}
