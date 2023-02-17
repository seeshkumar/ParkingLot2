using ParkingLot.Interfaces;
using ParkingLot.Models;
using ParkingLot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Injectors
{
    class Injector
    {
        InitializeSlotsService initializeSlotsService;
        ParkingSlotsFileService parkingSlotsFileService;
        TicketsFileService ticketsFileService;
        DriveVechileService driveVechileService;
        GetEmptySlotService getEmptySlotService;
        TicketManageService ticketManageService;
        public Injector(InitializeSlotsService initializeSlotsService, ParkingSlotsFileService parkingSlotsFileService, TicketsFileService ticketsFileService, DriveVechileService driveVechileService, GetEmptySlotService getEmptySlotService,TicketManageService ticketManageService) 
        { 

            this.initializeSlotsService = initializeSlotsService;
            this.parkingSlotsFileService = parkingSlotsFileService;
            this.ticketsFileService = ticketsFileService;
            this.driveVechileService = driveVechileService;
            this.getEmptySlotService = getEmptySlotService;
            this.ticketManageService = ticketManageService;
        }

        public void initializeLot(List<SlotCategoryCount> SlotCategoryCountObjs)
        {
            initializeSlotsService.InitializeLot(this, SlotCategoryCountObjs);
        }

        public List<Slot> ReadSlots()
        {
            return parkingSlotsFileService.ReadSlots();
        }
        public Boolean SaveSlots(List<Slot> slots)
        {
            return parkingSlotsFileService.SaveSlots(slots);
        }

        public List<Ticket> ReadTickets()
        {
            return ticketsFileService.ReadTickets();
        }
        public Boolean SaveTickets(List<Ticket> tickets)
        {
            return ticketsFileService.SaveTickets(tickets);
        }

        public string ParkVechile(List<Slot> slots, Vechile vechile)
        {
            return driveVechileService.ParkVechile(this, slots, vechile);
        }

        public string UnParkVechile(List<Slot> slots, string vechileNumber)
        {
            return driveVechileService.UnParkVechile(this, slots, vechileNumber);
        }

        public Slot getEmptySlot(string slotCategory, List<Slot> slots)
        {
            return getEmptySlotService.getEmptySlot(this, slotCategory, slots);
        }

        public Ticket GenerateTicket(Slot freeSlot, Vechile vechile)
        {
            return ticketManageService.GenerateTicket(this,freeSlot, vechile);
        }

        public void DeleteTicket(List<Ticket> tickets, Ticket ticket)
        {
            ticketManageService.DeleteTicket(this, tickets, ticket);
        }

    }
}
