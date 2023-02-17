using ParkingLot.Injectors;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    class GetEmptySlotService
    {
        public Slot getEmptySlot(Injector injector,string slotCategory, List<Slot> slots)
        {
            List<Ticket> tickets = injector.ReadTickets();
            Slot freeSlot = null;

            List<string> occupiedSlots = new List<string>();
            foreach (Ticket ticket in tickets)
            {
                occupiedSlots.Add(ticket.slot.slotName);
            }

            foreach (Slot slot in slots)
            {
                if (slot.slotCategory == slotCategory && !occupiedSlots.Contains(slot.slotName))
                {
                    freeSlot = slot;
                    break;
                }
            }

            return freeSlot;
        }
    }
}
