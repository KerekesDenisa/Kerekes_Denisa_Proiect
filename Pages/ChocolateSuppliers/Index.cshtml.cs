using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kerekes_Denisa_Proiect.Data;
using Kerekes_Denisa_Proiect.Models;

namespace Kerekes_Denisa_Proiect.Pages.ChocolateSuppliers
{
    public class IndexModel : PageModel
    {
        private readonly Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext _context;

        public IndexModel(Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext context)
        {
            _context = context;
        }

        public IList<ChocolateSupplier> ChocolateSupplier { get;set; }

        public async Task OnGetAsync()
        {
            ChocolateSupplier = await _context.ChocolateSupplier.ToListAsync();
        }
    }
}
