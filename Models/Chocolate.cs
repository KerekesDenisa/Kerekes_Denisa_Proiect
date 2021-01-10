using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kerekes_Denisa_Proiect.Models
{
    public class Chocolate
    {
        public int ID { get; set; }
        public string ChocolateName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime Expiration { get; set; }
        public int ChocolateSupplierID { get; set; }
        public ChocolateSupplier ChocolateSupplier { get; set; }
        public ICollection<ChocolateAssortment> ChocolateAssortments { get; set; }
    }
}

