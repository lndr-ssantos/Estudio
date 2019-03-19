using Estudio.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Estudio.Services {
	public class ConsumiveisServices : IConsumiveisServices {
		private readonly EstudioContext _context;

		public ConsumiveisServices(EstudioContext context) {
			_context = context;
		}

		public async Task<bool> AtualizarEstoque(int IdConsumivel, int quantidade) {
			var quantidadeEstoque = await VerificarEstoque(IdConsumivel);

			if (quantidade > quantidadeEstoque) {
				return false;
			} else {
				var consumivel = await _context.Consumiveis.FirstOrDefaultAsync(x => x.Id == IdConsumivel);
				consumivel.QuantidadeEstoque -= quantidade;
				_context.Entry(consumivel).Property("QuantidadeEstoque").IsModified = true;
				await _context.SaveChangesAsync();
				return true;
			}
		}

		public async Task<int> VerificarEstoque(int IdConsumivel) {
			var Consumivel = await _context.Consumiveis.FirstOrDefaultAsync(x => x.Id == IdConsumivel);
			return Consumivel.QuantidadeEstoque;
		}
	}
}
