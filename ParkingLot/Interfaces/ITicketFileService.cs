﻿using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    interface ITicketFileService
    {
        List<Ticket> ReadTickets();
        Boolean SaveTickets(List<Ticket> tickets);
    }
}
