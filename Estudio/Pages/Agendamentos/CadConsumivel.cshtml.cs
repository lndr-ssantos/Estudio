using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Estudio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Estudio.Pages.Agendamentos {
	public class CadConsumivelModel : PageModel {
		private const bool AgendamentoStatusAberto = true;
		private readonly EstudioContext _context;
		public List<SelectListItem> Agendamentos;
		public ControleConsumiveis ControleConsumiveis { get; set; }

		public CadConsumivelModel(EstudioContext context) {
			_context = context;
		}

		[BindProperty]
		public List<ControleConsumiveisViewModel> ConsumiveisViewModel { get; set; }

		public void OnGet() {
			Agendamentos = _context.Agendamentos
				.Where(x => x.Ativo == AgendamentoStatusAberto && x.Data == DateTime.Today)
				.Select(x => new SelectListItem {
					Value = x.IdAgendamento.ToString(),
					Text = $"{x.Banda.NomeBanda} - {x.Sala.Nome}"
				}).ToList();

			ConsumiveisViewModel = _context.Consumiveis
				.Select(x => new ControleConsumiveisViewModel() {
					IdConsumivel = x.Id,
					Descricao = x.Nome,
					Quantidade = 0,
					Valor = x.Valor
				}).ToList();
		}

		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			var IdAgendamento = ConsumiveisViewModel[0].IdAgendamento;
			foreach (var consumivel in ConsumiveisViewModel) {
				if (consumivel.Quantidade > 0) {
					ControleConsumiveis = new ControleConsumiveis {
						IdAgendamento = IdAgendamento,
						IdConsumivel = consumivel.IdConsumivel,
						Quantidade = consumivel.Quantidade
					};

					_context.ControleConsumiveis.Add(ControleConsumiveis);
				}
			}

			await _context.SaveChangesAsync();
			return RedirectToPage("../Index");
		}
   }
}