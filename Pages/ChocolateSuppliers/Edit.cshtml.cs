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

namespace Kerekes_Denisa_Proiect.Pages.ChocolateSuppliers
{
    public class EditModel : PageModel
    {
        private readonly Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext _context;

        public EditModel(Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChocolateSupplier ChocolateSupplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChocolateSupplier = await _context.ChocolateSupplier.FirstOrDefaultAsync(m => m.ID == id);

            if (ChocolateSupplier == null)
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

            _context.Attach(ChocolateSupplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChocolateSupplierExists(ChocolateSupplier.ID))
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

        private bool ChocolateSupplierExists(int id)
        {
            return _context.ChocolateSupplier.Any(e => e.ID == id);
        }
    }
}
