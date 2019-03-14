using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.Models {
	public class ControleConsumiveis {
		public int IdControle { get; set; }
		public int IdAgendamento { get; set; }
		public Agendamento Agendamento { get; set; }
		public int IdConsumivel { get; set; }
		public Consumivel Consumivel { get; set; }
		public int Quantidade { get; set; }
	}
}
