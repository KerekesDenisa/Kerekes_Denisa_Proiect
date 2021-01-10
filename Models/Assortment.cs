using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kerekes_Denisa_Proiect.Models
{
    public class Assortment
    {
        public int ID { get; set; }
        public string AssortmentName { get; set; }
        public ICollection<ChocolateAssortment> ChocolateAssortments { get; set; }

    }
}
