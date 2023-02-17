using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParkingLot.Injectors;

namespace ParkingLot.Interfaces
{
    interface IInitializeSlotService
    {
        void InitializeLot(Injector injector, List<SlotCategoryCount> slotCategoryCountObjs);
    }
}
