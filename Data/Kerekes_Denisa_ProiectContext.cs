using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kerekes_Denisa_Proiect.Models;

namespace Kerekes_Denisa_Proiect.Data
{
    public class Kerekes_Denisa_ProiectContext : DbContext
    {
        public Kerekes_Denisa_ProiectContext (DbContextOptions<Kerekes_Denisa_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Kerekes_Denisa_Proiect.Models.Chocolate> Chocolate { get; set; }

        public DbSet<Kerekes_Denisa_Proiect.Models.ChocolateSupplier> ChocolateSupplier { get; set; }

        public DbSet<Kerekes_Denisa_Proiect.Models.ChocolateAssortment> ChocolateAssortment { get; set; }
//public IEnumerable<object> Assortment { get; set; }
        public DbSet<Kerekes_Denisa_Proiect.Models.Assortment> Assortment { get; set; }
    }
}
