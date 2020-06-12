﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly AppDAL.PessoaContext _context;

        public DetailsModel(AppDAL.PessoaContext context)
        {
            _context = context;
        }

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
    }
}
