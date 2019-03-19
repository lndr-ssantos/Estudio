using System.Collections.Generic;

namespace Estudio.Models {
	public class Consumivel {
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Tipo { get; set; }
		public decimal Valor { get; set; }
		public int QuantidadeEstoque { get; set; }
		public IList<ControleConsumiveis> ControleConsumiveis { get; set; }
	}
}
