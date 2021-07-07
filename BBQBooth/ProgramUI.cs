using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBQBooth
{
    class ProgramUI
    {
        public PartyRepo _party = new PartyRepo();

        public void SeedData()
        {
            Ticket Burger = new Ticket(TicketType.Burger, 2.32, 1.43);
            Ticket Veggie = new Ticket(TicketType.Burger, 3.61, 1.43);
            Ticket HotDog = new Ticket(TicketType.Burger, 1.14, 1.43);
            Ticket IceCream = new Ticket(TicketType.Treat, 1, .51);
            Ticket[] tickets = new Ticket[] { Burger, Veggie, HotDog, IceCream };
            Random random = new Random();
            _party.AddParty(1);
            _party.AddParty(2);

            for (int i = 0; i < 100; i++)
            {
                int randomTicket = random.Next(0, 4);
                _party.CollectTicket(1, tickets[randomTicket]);
            }
            for (int i = 0; i < 100; i++)
            {
                int randomTicket = random.Next(0, 4);
                _party.CollectTicket(2, tickets[randomTicket]);
            }



        }
        public void Run()
        {
            SeedData();
            DisplayMenu();
        }
        public void DisplayMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Choose one of the following options\n" +
                    "1. See Specific Party Cost\n" +
                    "2. See All Parties\n" +
                    "3. See Specific Party Info\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        TotalCost();
                        break;
                    case "2":
                        ShowParties();
                        break;
                    case "3":
                        PartyBreakDown();
                        break;                    
                    case "4":
                        running = false;
                        break;
                }
            }
        }
        public void TotalCost()
        {
            Console.WriteLine("Enter the ID of the party you want the cost of");
            int id = int.Parse(Console.ReadLine());
            double total = 0;
            foreach(Ticket ticket in _party.GetParty()[id])
            {
                total = total + ticket.MealCost + ticket.MiscCost;
            }
            Console.WriteLine($"The total cost party {id} is ${total}");
            ToContinue();

        }
        public void ShowParties()
        {
            Console.WriteLine("Party Id Burger_Tickets Treat_Tickets Total_Cost");
            foreach(KeyValuePair<int,List<Ticket>> party in _party.GetParty())
            {
                Console.WriteLine($"{party.Key}\t {_party.GetTicketCount(party.Key, TicketType.Burger)}\t\t {_party.GetTicketCount(party.Key, TicketType.Treat)}\t\t ${_party.GetPartyCost(party.Key)}");
            }
            ToContinue();

        }
        public void PartyBreakDown()
        {
            Console.WriteLine("Enter the ID of the party you want the cost of");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine($"{id} Burger Tickets: {_party.GetTicketCount(id, TicketType.Burger)} Treat Tickets: {_party.GetTicketCount(id, TicketType.Treat)} Total Cost: ${_party.GetPartyCost(id)}");
            ToContinue();
        }
        public void ToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
