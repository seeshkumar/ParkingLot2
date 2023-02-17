using ParkingLot.Injectors;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    interface IDriveVechileService
    {
        string ParkVechile(Injector injector, List<Slot> slots, Vechile vechile);
        string UnParkVechile(Injector injector, List<Slot> slots, string number);
    }
}
