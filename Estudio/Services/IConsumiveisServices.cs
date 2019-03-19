using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.Services {
	public interface IConsumiveisServices {
		Task<bool> AtualizarEstoque(int IdConsumivel, int quantidade);
		Task<int> VerificarEstoque(int IdConsumivel);
	}
}
