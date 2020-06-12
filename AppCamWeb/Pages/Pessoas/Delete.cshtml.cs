using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppDAL;
using AppDomain;

namespace AppCamWeb.Pages.Pessoas
{
    public class DeleteModel : PageModel
    {
        private readonly AppDAL.PessoaContext _context;

        public DeleteModel(AppDAL.PessoaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pessoa Pessoa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pessoa = await _context.Pessoas.FirstOrDefaultAsync(m => m.Id == id);

            if (Pessoa == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pessoa = await _context.Pessoas.FindAsync(id);

            if (Pessoa != null)
            {
                _context.Pessoas.Remove(Pessoa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
