using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudio.Data;
using Estudio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Estudio.Pages.Consumiveis {
	public class ConsumiveisListModel : PageModel {
		private readonly EstudioContext _context;

		public ConsumiveisListModel(EstudioContext context) {
			_context = context;
		}

		[BindProperty]
		public List<Consumivel> Consumiveis { get; set; }

		public async Task OnGetAsync() {
			Consumiveis = await _context.Consumiveis.OrderBy(x => x.Id).ToListAsync();
      }
   }
}