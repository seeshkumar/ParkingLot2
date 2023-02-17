using ParkingLot.Injectors;
using ParkingLot.Interfaces;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    class TicketManageService : ITicketManageService
    {
        
        public Ticket GenerateTicket(Injector injector, Slot freeSlot, Vechile vechile)
        {
            List<Ticket> tickets = injector.ReadTickets();
            DateTime inTime = DateTime.Now;
            Ticket ticket = new Ticket(freeSlot, vechile, inTime);
            tickets.Add(ticket);
            injector.SaveTickets(tickets);
            return ticket;
        }

        public void DeleteTicket(Injector injector, List<Ticket> tickets, Ticket ticket)
        {
            tickets.Remove(ticket);
            injector.SaveTickets(tickets);
        }

    }

}
