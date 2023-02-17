using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Models;
using ParkingLot.Injectors;

namespace ParkingLot.Interfaces
{
    interface IParkingSlotsFileService
    {
        public List<Slot> ReadSlots();
        public Boolean SaveSlots(List<Slot> slots);

    }







}
