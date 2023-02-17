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
    class DriveVechileService : IDriveVechileService
    {
        public string ParkVechile(Injector injector, List<Slot> slots, Vechile vechile)
        {

                        Slot emptySlot = injector.getEmptySlot(vechile.vechileCategory, slots);
                        
                        if(emptySlot== null)
                        {
                            return "NO EMPTY SLOT FOR "+vechile.vechileCategory;
                        }

                        Ticket ticket = injector.GenerateTicket(emptySlot, vechile);
                        //ticket string
                        return $"VECHILE NUMBER : {ticket.vechile.vechileNumber} \nSLOT NAME : {ticket.slot.slotName} \nIN TIME : {ticket.inTime} \nOUT TIME : -";
                    
            //return "parkvechilefunc";
            }

        public string UnParkVechile(Injector injector, List<Slot> slots, string vechilNumber)
        {

            List<Ticket> tickets = injector.ReadTickets();

            Ticket ticket = tickets.FirstOrDefault(t => t.vechile.vechileNumber == vechilNumber);
            if (ticket == null)
            {
                return "Vechile not found";
            }

            DateTime outTime = DateTime.Now;
            string msg = $"VECHILE NUMBER : {ticket.vechile.vechileNumber} \nSLOT NAME : {ticket.slot.slotName} \nIN TIME : {ticket.inTime} \nOUT TIME : {outTime}";

            injector.DeleteTicket(tickets, ticket);

            return msg;
        }

        

    }
}
