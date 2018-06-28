using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Data
{
    public class BoxInventory
    { 
        [Key]
        public int Id { get; set; }

        [Range(1,int.MaxValue)]
        public int Weight { get; set; }

        [Range(1,int.MaxValue)]
        public int Volume { get; set; }

        public bool CanHoldLiquid { get; set; }

        [Range(1,int.MaxValue)]
        public double Cost { get; set; }

        public int InventoryCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
