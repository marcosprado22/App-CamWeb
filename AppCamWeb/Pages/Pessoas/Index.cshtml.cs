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
    public class IndexModel : PageModel
    {
        private readonly AppDAL.PessoaContext _context;

        public IndexModel(AppDAL.PessoaContext context)
        {
            _context = context;
        }

        public IList<Pessoa> Pessoa { get;set; }

        public async Task OnGetAsync()
        {
            Pessoa = await _context.Pessoas.ToListAsync();
        }
    }
}
