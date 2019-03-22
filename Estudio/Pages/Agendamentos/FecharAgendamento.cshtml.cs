using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Estudio.Pages.Agendamentos {
	public class FecharAgendamentoModel : PageModel {
		private readonly EstudioContext _context;

		public FecharAgendamentoModel(EstudioContext context) {
			_context = context;
		}

		[BindProperty]
		public Agendamento Agendamento { get; set; }

		public async Task<IActionResult> OnGetAsync(int? IdAgendamento) {
			if (IdAgendamento == null) {
				return NotFound();
			}

			Agendamento = await _context.Agendamentos
				.Include(agendamento => agendamento.Banda)
				.Include(agendamento => agendamento.ControleConsumiveis)
					.ThenInclude(controle => controle.Consumivel)
				.Include(agendamento => agendamento.Sala)
				.Include(agendamento => agendamento.Funcionario)
				.FirstOrDefaultAsync(x => x.IdAgendamento == IdAgendamento);

			CalcularValorTotal();

			if (Agendamento == null) {
				return NotFound();
			}

			return Page();
      }

		public async Task<IActionResult> OnPostAsync() {
			var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(x => x.IdAgendamento == Agendamento.IdAgendamento);
			agendamento.Ativo = false;
			agendamento.Valor = Agendamento.Valor;
			_context.Agendamentos.Update(agendamento);
			await _context.SaveChangesAsync();

			return RedirectToPage("../Dashboard");
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