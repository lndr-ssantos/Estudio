using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.Models {
	public class Consumivel {
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Tipo { get; set; }
		public decimal Valor { get; set; }
		public IList<ControleConsumiveis> ControleConsumiveis { get; set; }
	}
}
