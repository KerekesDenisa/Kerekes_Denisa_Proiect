using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kerekes_Denisa_Proiect.Data;


namespace Kerekes_Denisa_Proiect.Models
{
    public class ChocolateAssortmentsPageModel : PageModel
    {
        public List<AssignedAssortmentData> AssignedAssortmentDataList;
        public void PopulateAssignedAssortmentData(Kerekes_Denisa_ProiectContext context,
        Chocolate chocolate)
        {
            var allAssortments = context.Assortment;
            var chocolateAssortments = new HashSet<int>(
            chocolate.ChocolateAssortments.Select(c => c.ChocolateID));
            AssignedAssortmentDataList = new List<AssignedAssortmentData>();
            foreach (var cat in allAssortments)
            {
                AssignedAssortmentDataList.Add(new AssignedAssortmentData
                {
                    AssortmentID = cat.ID,
                    Name = cat.AssortmentName,
                    Assigned = chocolateAssortments.Contains(cat.ID)
                });
            }
        }
        public void UpdateChocolateAssortments(Kerekes_Denisa_ProiectContext context,
        string[] selectedAssortments, Chocolate chocolateToUpdate)
        {
            if (selectedAssortments == null)
            {
                chocolateToUpdate.ChocolateAssortments = new List<ChocolateAssortment>();
                return;
            }
            var selectedAssortmentsHS = new HashSet<string>(selectedAssortments);
            var chocolateAssortments = new HashSet<int>
            (chocolateToUpdate.ChocolateAssortments.Select(c => c.Assortment.ID));
            foreach (var cat in context.Assortment)
            {
                if (selectedAssortmentsHS.Contains(cat.ID.ToString()))
                {
                    if (!chocolateAssortments.Contains(cat.ID))
                    {
                        chocolateToUpdate.ChocolateAssortments.Add(
                        new ChocolateAssortment
                        {
                            ChocolateID = chocolateToUpdate.ID,
                            AssortmentID = cat.ID
                        });
                    }
                }
                else
                {
                    if (chocolateAssortments.Contains(cat.ID))
                    {
                        ChocolateAssortment courseToRemove
                        = chocolateToUpdate
                        .ChocolateAssortments
                        .SingleOrDefault(i => i.AssortmentID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
            }
        }
