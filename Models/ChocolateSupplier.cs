using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kerekes_Denisa_Proiect.Models
{
    public class ChocolateSupplier
    {
        public int ID { get; set; }
        public string ChocolateSupplierName { get; set; }
        public ICollection<Chocolate> Chocolates { get; set; }

    }
}
