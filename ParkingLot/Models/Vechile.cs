using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    class Vechile
    {
        public string vechileNumber { get; set; }
        public string vechileCategory { get; set; }

        public Vechile(string vechileNumber, string vechileCategory)
        {
            this.vechileNumber = vechileNumber;
            this.vechileCategory = vechileCategory;
        }
    }
}
