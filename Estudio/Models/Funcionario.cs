using System.Collections.Generic;

namespace Estudio.Models {
	public class Funcionario {
		public int IdFuncionario { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public IList<Agendamento> Agendamentos { get; set; }
	}
}