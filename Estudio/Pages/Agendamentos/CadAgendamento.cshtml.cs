﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.GlobalConfiguracao;
using Estudio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Estudio.Pages.Agendamentos {
	public class CadAgendamentoModel : PageModel {
		private readonly EstudioContext _context;
		//Lista de bandas para o select
		public List<SelectListItem> Bandas;
		//Lista de salas para o select
		public List<SelectListItem> Salas;

		public CadAgendamentoModel(EstudioContext context) {
			_context = context;
		}

		[BindProperty]
		public Agendamento Agendamento { get; set; }

		public void OnGet() {
			Bandas = _context.Bandas
				.Select(x => new SelectListItem {
					Value = x.IdBanda.ToString(),
					Text = x.NomeBanda
				}).ToList();

			Salas = _context.Salas
					.Select(x => new SelectListItem {
						Value = x.IdSala.ToString(),
						Text = x.Nome
					}).ToList();
		}

		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			Agendamento.Ativo = true;
			Agendamento.IdFuncionario = HttpContext.Session.GetInt32(SessionConfiguracao.SessionChaveIdFuncionario);

			_context.Agendamentos.Add(Agendamento);
			await _context.SaveChangesAsync();

			return RedirectToPage("../Dashboard");
		}
   }
}