using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kerekes_Denisa_Proiect.Models
{
    public class ChocolateData
    {
        public IEnumerable<Chocolate> Chocolates { get; set; }
        public IEnumerable<Assortment> Assortments { get; set; }
        public IEnumerable<ChocolateAssortment> ChocolateAssortments { get; set; }

    }
}
