using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppDAL;
using AppDomain;

namespace AppCamWeb.Pages.Pessoas
{
    public class CreateModel : PageModel
    {
        private readonly AppDAL.PessoaContext _context;

        public CreateModel(AppDAL.PessoaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pessoa Pessoa { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pessoas.Add(Pessoa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
