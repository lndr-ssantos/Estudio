using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Estudio.Pages.Consumiveis {
	public class CadConsumivelModel : PageModel {
		private readonly EstudioContext _context;

		public CadConsumivelModel(EstudioContext context) {
			_context = context;
		}

		[BindProperty]
		public Consumivel Consumivel { get; set; }

		public void OnGet() {

      }

		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			_context.Consumiveis.Add(Consumivel);
			await _context.SaveChangesAsync();

			return RedirectToPage("../Dashboard");
		}
   }
}