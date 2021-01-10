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

namespace Kerekes_Denisa_Proiect.Pages.Chocolates
{
    public class EditModel : ChocolateAssortmentsPageModel
    {
        private readonly Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext _context;

        public EditModel(Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Chocolate Chocolate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Chocolate = await _context.Chocolate
 .Include(b => b.ChocolateSupplier)
 .Include(b => b.ChocolateAssortments).ThenInclude(b => b.Assortment)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);


            if (Chocolate == null)
            {
                return NotFound();
            }
            PopulateAssignedAssortmentData(_context, Chocolate);
            ViewData["ChocolateSupplierID"] = new SelectList(_context.Set<ChocolateSupplier>(), "ID", "ChocolateSupplierName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedAssortments)
        {
            if (id == null)
            {
                return NotFound();
            }
            var chocolateToUpdate = await _context.Chocolate
            .Include(i => i.ChocolateSupplier)
            .Include(i => i.ChocolateAssortments)
            .ThenInclude(i => i.Assortment)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (chocolateToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Chocolate>(
            chocolateToUpdate,
            "Chocolate",
            i => i.ChocolateName, i => i.Description,
            i => i.Price, i => i.Expiration, i => i.ChocolateSupplier))
            {
                UpdateChocolateAssortments(_context, selectedAssortments, chocolateToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateChocolateAssortments pentru a aplica informatiile din checkboxuri la entitatea Chocolates care
            //este editata
            UpdateChocolateAssortments(_context, selectedAssortments, chocolateToUpdate);
            PopulateAssignedAssortmentData(_context, chocolateToUpdate);
            return Page();
        }
  
}
}
