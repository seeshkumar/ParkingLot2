using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParkingLot.Interfaces;
using System.Xml.Linq;
using ParkingLot.Injectors;

namespace ParkingLot.Services
{
    class InitializeSlotsService : IInitializeSlotService
    {
        public void InitializeLot(Injector injector, List<SlotCategoryCount> slotCategoryCountObjs) 
        {

            string name;
            List<Slot> slots = new List<Slot>();

            foreach(SlotCategoryCount slotCategoryCountObj in slotCategoryCountObjs)
            {
                for (int index = 0; index < slotCategoryCountObj.slotCount; index++)
                {
                    name = slotCategoryCountObj.slotCategory+Convert.ToString(index + 1);
                    slots.Add(new Slot(name, slotCategoryCountObj.slotCategory));
                }
            }

            injector.SaveSlots(slots);
            injector.SaveTickets(new List<Ticket>());//clearing tickets db
        }
    }
}
