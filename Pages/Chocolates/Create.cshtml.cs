using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kerekes_Denisa_Proiect.Data;
using Kerekes_Denisa_Proiect.Models;

namespace Kerekes_Denisa_Proiect.Pages.Chocolates
{
    public class CreateModel : ChocolateAssortmentsPageModel
    {
        private readonly Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext _context;

        public CreateModel(Kerekes_Denisa_Proiect.Data.Kerekes_Denisa_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ChocolateSupplierID"] = new SelectList(_context.Set<ChocolateSupplier>(), "ID", "ChocolateSupplierName");
            var chocolate = new Chocolate();
            chocolate.ChocolateAssortments = new List<ChocolateAssortment>();
            PopulateAssignedAssortmentData(_context, chocolate);

            return Page();
        }

        [BindProperty]
        public Chocolate Chocolate { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedAssortments)
        {
            var newAssortment = new Assortment();
            Chocolate newChocolate = null;
            if (selectedAssortments != null)
            {
                newChocolate.ChocolateAssortments = new List<ChocolateAssortment>();
                foreach (var assort in selectedAssortments)
                {
                    var assortToAdd = new ChocolateAssortment
                    {
                        AssortmentID = int.Parse(assort)
                    };
                    newChocolate.ChocolateAssortments.Add(assortToAdd);
                }
            }

            if (await TryUpdateModelAsync<Chocolate>(
            newChocolate,
            "Chocolate",
            i => i.ChocolateName, i => i.Description,
            i => i.Price, i => i.Expiration, i => i.ChocolateSupplierID))
            {
                _context.Chocolate.Add(newChocolate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedAssortmentData(_context, newChocolate);
            return Page();
        }

    }
}
