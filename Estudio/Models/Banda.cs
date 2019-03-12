using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.Models {
	public class Banda {
		public int IdBanda { get; set; }
		public string NomeBanda { get; set; }
		public short QtdIntegrantes { get; set; }
		public string NomeResponsavel { get; set; }
		public string TelResponsavel { get; set; }
		public string EmailResponsavel { get; set; }
		public string CPFResponsavel { get; set; }
	}
}
