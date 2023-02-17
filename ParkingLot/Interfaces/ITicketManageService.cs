using ParkingLot.Injectors;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    interface ITicketManageService
    {
        Ticket GenerateTicket(Injector injector, Slot freeSlot, Vechile vechile);
        void DeleteTicket(Injector injector, List<Ticket> tickets, Ticket ticket);
    }
}
