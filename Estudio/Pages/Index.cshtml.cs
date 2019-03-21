using Estudio.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Estudio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Estudio.GlobalConfiguracao;

namespace Estudio.Pages {
	public class IndexModel : PageModel {
		private readonly EstudioContext _context;

		public IndexModel(EstudioContext context) {
			_context = context;
		}

		[BindProperty]
		public Funcionario Funcionario { get; set; }

		public void OnGet() {

      }

		public async Task<IActionResult> OnPostAsync() {
			var funcionario = await _context.Funcionarios.Where(x => x.Email == Funcionario.Email && x.Senha == Funcionario.Senha).FirstOrDefaultAsync();

			if (funcionario != null) {
				HttpContext.Session.SetString(SessionConfiguracao.SessionChaveNome, funcionario.Nome);
				HttpContext.Session.SetInt32(SessionConfiguracao.SessionChaveEstaLogado, 1);

				return RedirectToPage("./Dashboard");
			}

			return Page();
		}
	}
}