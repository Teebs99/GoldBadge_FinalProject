using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    class ProgramUI
    {
        protected readonly BadgeRepo _badges = new BadgeRepo();
        public void SeedContent()
        {
            List<string> doors = new List<string>() { "A5", "B6", "C2" };
            Badge item1 = new Badge(1,doors);
            Badge item2 = new Badge(2,doors);
            Badge item3 = new Badge(3,doors);
            _badges.AddBadge(item1);
            _badges.AddBadge(item2);
            _badges.AddBadge(item3);

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
                    "1. Add Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ShowBadges();
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

        public void AddBadge()
        {
            Console.Write("What is the number on the badge: ");
            int id = int.Parse(Console.ReadLine());
            _badges.AddBadge(new Badge(id));
            bool addDoors = true;
            while (addDoors)
            {
                Console.Write("\nList a door that it needs access to: ");
                string door = Console.ReadLine();
                _badges.AddDoor(id, door);
                Console.Write("\nAny other doors y/n ");
                string input = Console.ReadLine();
                if(input.ToLower() == "n") { addDoors = false; }
            }
            ToContinue();
        }
        public void UpdateBadge()
        {
            Console.Write("What is the badge number to update? ");
            int id = int.Parse(Console.ReadLine());
            Console.Write($"\n{id} has access to doors ");
            ShowDoors(id);
            Console.WriteLine("\nWhat would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Write("\nWhich door would you like to remove? ");
                    string doorToRemove = Console.ReadLine();
                    if(_badges.DeleteDoor(id, doorToRemove))
                    {
                        Console.WriteLine("\nDoor Removed");
                    }
                    ShowDoors(id);
                    break;
                case 2:
                    Console.Write("\nWhich door would you like to add ");
                    string doorToAdd = Console.ReadLine();
                    _badges.AddDoor(id, doorToAdd);
                    Console.Write("Door added");
                    ShowDoors(id);
                    break;
            }
            ToContinue();
        }
        public void ShowBadges()
        {
            foreach(int id in _badges.GetBadges().Keys)
            {
                ShowDoors(id);
            }
            
            ToContinue();
        }
        public void ShowDoors(int id)
        {
            Console.Write($"\n{id} has access to doors ");
            foreach (string door in _badges.GetBadges()[id])
            {
                Console.Write(door + ", ");
            }

        }
    }
}
