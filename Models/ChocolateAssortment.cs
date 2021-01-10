using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kerekes_Denisa_Proiect.Models
{
    public class ChocolateAssortment
    {
        public int ID { get; set; }
        public int ChocolateID { get; set; }
        public Chocolate Chocolate { get; set; }
        public int AssortmentID { get; set; } 
        public Assortment Assortment { get; set; }

       
    }
}
