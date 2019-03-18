using System.Collections.Generic;

namespace Estudio.Models {
	public class Sala {
		public int IdSala { get; set; }
		public string Nome { get; set; }
		public string Tipo { get; set; }
		public decimal Valor { get; set; }
		public IList<Agendamento> Agendamentos { get; set; }
	}
}