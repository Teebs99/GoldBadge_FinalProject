using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    class ProgramUI
    {
        protected readonly OutingRepo _repo = new OutingRepo();
        public void SeedContent()
        {
            Outing item1 = new Outing(EventType.Golf,3,DateTime.Now,150d);
            Outing item2 = new Outing(EventType.Concert, 12, DateTime.Now, 450d);
            Outing item3 = new Outing(EventType.Bowling, 6, DateTime.Now, 50d);
            _repo.AddOuting(item1);
            _repo.AddOuting(item2);
            _repo.AddOuting(item3);

        }
        public void Run()
        {
            SeedContent();
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Select From The Following Options\n" +
                    "1. Show All Outings\n" +
                    "2. Add Outing\n" +
                    "3. Calculations\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        ShowOutings();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                        Calculations();
                        break;
                    case "4":
                        running = false;
                        break;
                }
            }


        }
        public void ToContinue()
        {
            Console.WriteLine("\nPress Any Key To Continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void AddOuting()
        {
            Console.WriteLine("What type of outing was it\n" +
                "1. Golf\n" +
                "2.Bowling\n" +
                "3. Amusement Park\n" +
                "4.Concert");
            EventType type = (EventType) int.Parse(Console.ReadLine());
            Console.WriteLine("How many people attended the event?");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter year of event");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter month of event");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter day of event");
            int day = int.Parse(Console.ReadLine());
            DateTime time = new DateTime(year, month, day);
            Console.WriteLine("What was the total cost of the event?");
            double cost = double.Parse(Console.ReadLine());
            _repo.AddOuting(new Outing(type, num, time, cost));
            ToContinue();
        }
        public void Calculations()
        {
            
            double total = 0;
            double bowling = 0;
            double concert = 0;
            double park = 0;
            double golf = 0;
            foreach(Outing outing in _repo.GetOutings())
            {
                total += outing.Cost;
                switch (outing.Type)
                {
                    case EventType.Golf:
                        golf += outing.Cost;
                        break;
                    case EventType.Bowling:
                        bowling += outing.Cost;
                        break;
                    case EventType.Concert:
                        concert += outing.Cost;
                        break;
                    case EventType.Amusement_Park:
                        park += outing.Cost;
                        break;
                }
            }
            Console.WriteLine("\nWhat would you like to do?\n" +
                "1. Cost of all outings\n" +
                "2. Show outing costs by type");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("Total cost: $" + total);
                    break;
                case 2:
                    Console.WriteLine("Concerts: $" + concert);
                    Console.WriteLine("Bowling: $" + bowling);
                    Console.WriteLine("Amusement Park: $" + park);
                    Console.WriteLine("Golf: $" + golf);

                    break;
            }
            ToContinue();
        }
        public void ShowOutings()
        {
            Console.WriteLine("Outing Type\tNumber of People\tDate\t\tCost Per Person\tTotal Cost");
            foreach(Outing outing in _repo.GetOutings())
            {
                Console.WriteLine($"{outing.Type}\t\t\t{outing.NumPeople}\t{outing.Date}\t${Math.Round(outing.CostPerPerson)}/person\t${outing.Cost}");
            }
            ToContinue();
        }
    }
}
