using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Estudio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Estudio.Pages.Agendamentos {
	public class FecharAgendamentoListModel : PageModel {
		private readonly EstudioContext _context;
		public List<AgendamentoViewModel> Agendamentos { get; set; }
		public List<Agendamento> Ag2 { get; set; }

		public FecharAgendamentoListModel(EstudioContext context) {
			_context = context;
		}

		public void OnGet() {
			Agendamentos = _context.Agendamentos
				.Where(x => x.Ativo == true && x.Data == DateTime.Today)
				.Select(x => new AgendamentoViewModel() {
				IdAgendamento = x.IdAgendamento,
				NomeBanda = x.Banda.NomeBanda,
				NomeSala = x.Sala.Nome
			}).ToList();

			Ag2 = _context.Agendamentos.ToList();
		}
   }
}