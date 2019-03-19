using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Estudio.Pages.Instrumentos {
	public class CadInstrumentoModel : PageModel {
		private readonly EstudioContext _context;

		public CadInstrumentoModel(EstudioContext context) {
			_context = context;
		}

		[BindProperty]
		public Instrumento Instrumento { get; set; }

		public void OnGet() {

      }

		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			_context.Instrumentos.Add(Instrumento);
			await _context.SaveChangesAsync();

			return RedirectToPage("../Index");
		}
   }
}