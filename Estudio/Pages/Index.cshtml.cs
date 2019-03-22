using Estudio.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Estudio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Estudio.GlobalConfiguracao;
using System.Security.Cryptography;
using System.Text;

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
			string senhaMd5;
			using (MD5 md5Hash = MD5.Create()) {
				senhaMd5 = GetMd5Hash(md5Hash, Funcionario.Senha);
			}

			var funcionario = await _context.Funcionarios.Where(x => x.Email == Funcionario.Email && x.Senha == senhaMd5).FirstOrDefaultAsync();

			if (funcionario != null) {
				HttpContext.Session.SetString(SessionConfiguracao.SessionChaveNome, funcionario.Nome);
				HttpContext.Session.SetInt32(SessionConfiguracao.SessionChaveEstaLogado, 1);

				return RedirectToPage("./Dashboard");
			}

			return Page();
		}

		private string GetMd5Hash(MD5 md5Hash, string senha) {
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

			StringBuilder sBuilder = new StringBuilder();

			foreach (var byteData in data) {
				sBuilder.Append(byteData.ToString("x2"));
			}

			return sBuilder.ToString();
		}
	}
}