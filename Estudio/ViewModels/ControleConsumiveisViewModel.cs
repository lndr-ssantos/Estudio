using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.ViewModels {
	public class ControleConsumiveisViewModel {
		public int IdAgendamento { get; set; }
		public int IdConsumivel { get; set; }
		public int Quantidade { get; set; }
		public string Descricao { get; set; }
		public decimal Valor { get; set; }
	}
}
