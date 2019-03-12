using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Estudio.Pages.Agendamentos {
	public class CadAgendamentoModel : PageModel {
		private readonly EstudioContext _context;
		//Lista de bandas para o select
		public List<SelectListItem> Bandas => _context.Banda
				.Select(x => new SelectListItem {
					Value = x.IdBanda.ToString(),
					Text = x.NomeBanda
				}).ToList();
		//Lista de salas para o select
		public List<SelectListItem> Salas => _context.Sala
			.Select(x => new SelectListItem {
				Value = x.IdSala.ToString(),
				Text = x.Nome
			}).ToList();

		public CadAgendamentoModel(EstudioContext context) {
			_context = context;
		}

		[BindProperty]
		public Agendamento Agendamento { get; set; }

		public void OnGet() {

		}

		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			_context.Agendamento.Add(Agendamento);
			await _context.SaveChangesAsync();

			return RedirectToPage("../Index");
		}
   }
}