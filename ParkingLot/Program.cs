
using ParkingLot.Injectors;
using ParkingLot.Interfaces;
using ParkingLot.Models;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

using ParkingLot.Services;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    public static void Main(string[] args)
    {
        int mode;
        string vechileNumber;
        string vechileCategory;
        string msg;
        
        HashSet<string> allowedSlotCategories= new HashSet<string>() { "TWOWHEELER", "FOURWHEELER", "NEW"};
        allowedSlotCategories.Add("Heavy");
        
        bool endProgram = false;
        while (!endProgram)
        {
            Console.WriteLine("\n\n1.Initialize a parking lot.\n2.See Parking Lot current occupancy details.\n3.Park Vehicle and Issue Ticket.\n4.Un-park Vehicle.\n5.End   :");
            mode = Convert.ToInt32(Console.ReadLine());

            InitializeSlotsService initializeSlotsService = new InitializeSlotsService();
            ParkingSlotsFileService parkingSlotsFileService = new ParkingSlotsFileService();
            TicketsFileService ticketsFileService = new TicketsFileService();
            DriveVechileService driveVechileService = new DriveVechileService();
            GetEmptySlotService getEmptySlotService = new GetEmptySlotService();
            TicketManageService ticketManageService = new TicketManageService();

            Injector injector = new Injector(initializeSlotsService, parkingSlotsFileService, ticketsFileService, driveVechileService, getEmptySlotService, ticketManageService);


            List<Slot> slots;
            List<Ticket> tickets;
            switch (mode)
            {
                case 1:


                    Console.WriteLine("-----------ALLOWED CATEGORIES-----------");
                    foreach (string category in allowedSlotCategories)
                    {
                        Console.WriteLine(category);
                    }
                    Console.WriteLine("-----------------------------------------");


                    Console.WriteLine("-------- Initializing Lot --------");
                    bool enteringSlots = true;
                    List<SlotCategoryCount> slotCategoryCountObjs = new List<SlotCategoryCount>();
                    while (enteringSlots)
                    {
                        SlotCategoryCount slotCategoryCount= new SlotCategoryCount();
                        string slotCategory;
                        string slotCount;
                        Console.Write("\nEnter Slot Category Name(-1 to stop) : ");
                        slotCategory = Console.ReadLine();
                        if(slotCategory == "-1")
                        {
                            enteringSlots = false;
                            break;
                        }
                        if (!allowedSlotCategories.Contains(slotCategory))
                        {
                            Console.WriteLine("Slot type "+slotCategory+" not allowed.\n");
                            continue;
                        }
                        slotCategoryCount.slotCategory = slotCategory;
                        Console.Write("Enter number of "+ slotCategoryCount.slotCategory + " slots :");
                        slotCategoryCount.slotCount = Convert.ToInt32(Console.ReadLine());

                        slotCategoryCountObjs.Add(slotCategoryCount);

                    }
                    injector.initializeLot(slotCategoryCountObjs);
                    Console.WriteLine("Initialized Slots");
                    break;
                case 2:
                    slots = injector.ReadSlots();
                    tickets = injector.ReadTickets();
                    foreach (Slot slot in slots)
                    {
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine($"SLOT : {slot.slotName}\nSLOT CATEGORY : {slot.slotCategory}");

                        Ticket slotTicket = tickets.FirstOrDefault(t => t.slot.slotName == slot.slotName);
                        if (slotTicket == null)
                        {
                            Console.WriteLine("-- EMPTY SLOT --");
                        }
                        else
                        {
                            Console.WriteLine($"OCCUPIED BY : {slotTicket.vechile.vechileNumber}");
                        }
                        Console.WriteLine("--------------------------------------");
                    }
                    break;
                case 3:
                    slots = injector.ReadSlots();
                    Console.Write("Vechile number : ");
                    vechileNumber = Console.ReadLine();
                    Console.Write("Category :");
                    vechileCategory = Console.ReadLine();
                    msg = "Could not park vechile.";

                    msg = injector.ParkVechile(slots, new Vechile(vechileNumber, vechileCategory));

                    Console.WriteLine("\n\n----------- TICKET -----------");
                    Console.WriteLine(msg);
                    Console.WriteLine("------------------------------");
                    break;
                case 4:
                    slots = injector.ReadSlots();
                    Console.Write("Vechile number : ");
                    vechileNumber = Console.ReadLine();
                    msg = injector.UnParkVechile(slots, vechileNumber);
                    Console.WriteLine("----------- TICKET -----------");
                    Console.WriteLine(msg);
                    Console.WriteLine("------------------------------");
                    break;
                case 5:
                    endProgram = true;
                    break;
                default:
                    break;

            }


        }







    }

}
