using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kerekes_Denisa_Proiect.Data;
using Kerekes_Denisa_Proiect.Models;

namespace Kerekes_Denisa_Proiect.Pages.ChocolateAssortments
{
    public class EditModel : PageModel
    {
        private readonly Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext _context;

        public EditModel(Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assortment Assortment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assortment = await _context.Assortment.FirstOrDefaultAsync(m => m.ID == id);

            if (Assortment == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Assortment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssortmentExists(Assortment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AssortmentExists(int id)
        {
            return _context.Assortment.Any(e => e.ID == id);
        }
    }
}
