using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Estudio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Estudio.Pages.Agendamentos {
	public class FecharAgendamentoModel : PageModel {
		private readonly EstudioContext _context;
		public Agendamento Agendamento { get; set; }

		public FecharAgendamentoModel(EstudioContext context) {
			_context = context;
		}

		public async Task<IActionResult> OnGetAsync(int? IdAgendamento) {
			if (IdAgendamento == null) {
				return NotFound();
			}

			Agendamento = await _context.Agendamentos
				.Include(agendamento => agendamento.Banda)
				.Include(agendamento => agendamento.ControleConsumiveis)
					.ThenInclude(controle => controle.Consumivel)
				.Include(agendamento => agendamento.Sala)
				.FirstOrDefaultAsync(x => x.IdAgendamento == IdAgendamento);

			CalcularValorTotal();

			if (Agendamento == null) {
				return NotFound();
			}

			return Page();
      }

		public async Task<IActionResult> OnPostAsync(int? IdAgendamento) {
			var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(x => x.IdAgendamento == IdAgendamento);
			agendamento.Ativo = false;
			_context.Entry(agendamento).Property("Ativo").IsModified = true;
			await _context.SaveChangesAsync();

			return RedirectToPage("../Index");
		}

		private void CalcularValorTotal() {
			Agendamento.Valor = 0; //Inicia o valor com 0, pois ele é nulo por padrão
			foreach (var consumivel in Agendamento.ControleConsumiveis) {
				var valorTotalConsumivel = consumivel.Consumivel.Valor * consumivel.Quantidade;
				Agendamento.Valor += valorTotalConsumivel;
			}
		}
	}
}