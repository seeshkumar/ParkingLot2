using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    class Slot
    {
        public string slotName { get; set; }
        public string slotCategory { get; set; }

        public Slot(string slotName, string slotCategory)
        {
            this.slotName = slotName;
            this.slotCategory = slotCategory;
        }
    }
}
