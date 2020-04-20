using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DunkinDonuts.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public int UserId { get; set; }
        public decimal RemainingBalance { get; set; }

    }
}
