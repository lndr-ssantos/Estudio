using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Estudio.Pages.Instrumentos {
	public class InstrumentosListModel : PageModel {
		private readonly EstudioContext _context;
		public List<Instrumento> Instrumentos { get; set; }

		public InstrumentosListModel(EstudioContext context) {
			_context = context;
		}

		public void OnGetAsync() {
			Instrumentos = _context.Instrumentos.ToList();
      }
   }
}