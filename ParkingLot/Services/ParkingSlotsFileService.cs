using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParkingLot.Injectors;
using ParkingLot.Interfaces;
using ParkingLot.Models;


namespace ParkingLot.Services
{
    class ParkingSlotsFileService : IParkingSlotsFileService
    {


        public List<Slot> ReadSlots()
        {
            string slotsJson = File.ReadAllText("./assets/slots.json");
            List<Slot> slots = JsonConvert.DeserializeObject<List<Slot>>(slotsJson);
            return slots;

        }

        public Boolean SaveSlots(List<Slot> slots)
        {
            try
            {
                string json = JsonConvert.SerializeObject(slots);
                File.WriteAllText("./assets/Slots.json", json);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        
        
        
    }
}
