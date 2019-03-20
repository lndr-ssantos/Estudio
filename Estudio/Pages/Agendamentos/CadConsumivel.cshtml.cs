using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Estudio.Services;
using Estudio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Estudio.Pages.Agendamentos {
	public class CadConsumivelModel : PageModel {
		private const bool AgendamentoStatusAberto = true;
		private readonly EstudioContext _context;
		private readonly IConsumiveisServices _consumiveisServices;
		public List<string> Mensagens { get; set; }
		public List<SelectListItem> Agendamentos;
		public ControleConsumiveis ControleConsumiveis { get; set; }

		public CadConsumivelModel(EstudioContext context, IConsumiveisServices consumiveisServices) {
			_context = context;
			_consumiveisServices = consumiveisServices;
		}

		[BindProperty]
		public List<ControleConsumiveisViewModel> ConsumiveisViewModel { get; set; }

		public async Task OnGet() {
			await CarregarListas();
		}

		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			Mensagens = new List<string>();
			var IdAgendamento = ConsumiveisViewModel[0].IdAgendamento;
			foreach (var consumivel in ConsumiveisViewModel) {
				if (consumivel.Quantidade > 0) {
					ControleConsumiveis = new ControleConsumiveis {
						IdAgendamento = IdAgendamento,
						IdConsumivel = consumivel.IdConsumivel,
						Quantidade = consumivel.Quantidade
					};

					var atualizacaoEstoque = await _consumiveisServices.AtualizarEstoque(consumivel.IdConsumivel, consumivel.Quantidade);

					if (atualizacaoEstoque) {
						_context.ControleConsumiveis.Add(ControleConsumiveis);
					} else {
						Mensagens.Add($"O consumível {consumivel.Descricao} não tem {consumivel.Quantidade} unidades disponíveis");
					}
				}
			}

			if (Mensagens.Count > 0) {
				await CarregarListas();
				return Page();
			}

			await _context.SaveChangesAsync();
			return RedirectToPage("../Index");
		}

		private async Task CarregarListas() {
			Agendamentos = await _context.Agendamentos
			.Where(x => x.Ativo == AgendamentoStatusAberto && x.Data == DateTime.Today)
			.Select(x => new SelectListItem {
				Value = x.IdAgendamento.ToString(),
				Text = $"{x.Banda.NomeBanda} - {x.Sala.Nome}"
			}).ToListAsync();

			ConsumiveisViewModel = await _context.Consumiveis
				.Where(x => x.QuantidadeEstoque > 0)
				.Select(x => new ControleConsumiveisViewModel() {
					IdConsumivel = x.Id,
					Descricao = x.Nome,
					Quantidade = 0,
					Valor = x.Valor,
					QuantidadeEstoque = x.QuantidadeEstoque
				}).OrderBy(x => x.IdConsumivel).ToListAsync();
		}
	}
}