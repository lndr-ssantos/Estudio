using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Estudio.Pages.Consumiveis {
	public class EditarConsumivelModel : PageModel {
		private readonly EstudioContext _context;

		public EditarConsumivelModel(EstudioContext context) {
			_context = context;
		}

		[BindProperty]
		public Consumivel Consumivel { get; set; }

		public async Task<IActionResult> OnGetAsync(int? idConsumivel) {
			if (idConsumivel == null) {
				return NotFound();
			}

			Consumivel = await _context.Consumiveis.FirstOrDefaultAsync(x => x.Id == idConsumivel);

			if (Consumivel == null) {
				return NotFound();
			}

			return Page();
      }

		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			_context.Attach(Consumivel).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			
			TempData["MensagemAtualizacaoConsumivel"] = "Consumível atualizado!";
			return RedirectToPage("./ConsumiveisList");
		}
   }
}