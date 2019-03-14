using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Estudio.Pages.Bandas {
	public class CadBandaModel : PageModel {
		private readonly EstudioContext _context;

		public CadBandaModel(EstudioContext context) {
			_context = context;
		}

		[BindProperty]
		public Banda Banda { get; set; }

		public void OnGet() {

		}

		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			_context.Bandas.Add(Banda);
			await _context.SaveChangesAsync();

			return RedirectToPage("../Index");
		}
	}
}
