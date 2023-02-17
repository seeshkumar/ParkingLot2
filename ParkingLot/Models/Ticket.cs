using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    class Ticket
    {
        public Slot slot { get; set; }
        public Vechile vechile { get; set; }
        public DateTime inTime { get; set; }
        public DateTime outTime { get; set; }

        public Ticket(Slot slot, Vechile vechile, DateTime inTime)
        {
            this.slot = slot;
            this.vechile = vechile;
            this.inTime = inTime;
        }
    }
}
