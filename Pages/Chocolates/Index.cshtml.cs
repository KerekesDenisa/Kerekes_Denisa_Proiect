using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kerekes_Denisa_Proiect.Data;
using Kerekes_Denisa_Proiect.Models;

namespace Kerekes_Denisa_Proiect.Pages.Chocolates
{
    public class IndexModel : PageModel
    {
        private readonly Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext _context;

        public IndexModel(Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext context)
        {
            _context = context;
        }

        public IList<Chocolate> Chocolate { get;set; }
        public ChocolateData ChocolateD { get; set; }
        public int ChocolateID { get; set; }
        public int AssortmentID { get; set; }
        public async Task OnGetAsync(int? id, int? assortmentID)
        {
            ChocolateD = new ChocolateData();

            ChocolateD.Chocolates = await _context.Chocolate
            .Include(b => b.ChocolateSupplier)
            .Include(b => b.ChocolateAssortments)
            .ThenInclude(b => b.Assortment)
            .AsNoTracking()
            .OrderBy(b => b.ChocolateName)
            .ToListAsync();
            if (id != null)
            {
                ChocolateID = id.Value;
                Chocolate chocolate = ChocolateD.Chocolates
                .Where(i => i.ID == id.Value).Single();
                ChocolateD.Chocolates = (IEnumerable<Chocolate>)chocolate.ChocolateAssortments.Select(s => s.Assortment);
            }
        }

    }
}
