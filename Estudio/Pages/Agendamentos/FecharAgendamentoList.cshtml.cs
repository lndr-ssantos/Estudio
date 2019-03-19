using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Estudio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Estudio.Pages.Agendamentos {
	public class FecharAgendamentoListModel : PageModel {
		private readonly EstudioContext _context;
		public List<Agendamento> Agendamentos { get; set; }

		public FecharAgendamentoListModel(EstudioContext context) {
			_context = context;
		}

		public void OnGet() {
			Agendamentos = _context.Agendamentos
				.Where(x => x.Ativo == true && x.Data == DateTime.Today)
				.Include(agendamento => agendamento.Banda)
				.Include(agendamento => agendamento.Sala)
				.ToList();
		}
   }
}