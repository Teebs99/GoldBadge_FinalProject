using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_FinalProject
{
    class ProgramUI
    {
        protected readonly MenuRepository _menu = new MenuRepository();

        public void SeedContent()
        {
            Menu item1 = new Menu(1, "Item1", "Desc1", "Test1", 4.22d);
            Menu item2 = new Menu(2, "Item2", "Desc2", "Test2", 5.42d);
            Menu item3 = new Menu(3, "Item3", "Desc3", "Test3", 9.27d);
            _menu.AddMenuItem(item1);
            _menu.AddMenuItem(item2);
            _menu.AddMenuItem(item3);

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
                    "1. Add Item To Menu\n" +
                    "2. Delete Item From Menu\n" +
                    "3. See Menu\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        DeleteItem();
                        break;
                    case "3":
                        ShowMenu();
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

        public void AddItem()
        {
            Console.WriteLine("Enter the meal number");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the meal name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the meal description");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter the list of ingredients");
            string ingredients = Console.ReadLine();
            Console.WriteLine("Enter the price ex: 4.25");
            double price = double.Parse(Console.ReadLine());
            Menu item = new Menu(number, name, desc, ingredients, price);
            _menu.AddMenuItem(item);
            ToContinue();
        }
        public void DeleteItem()
        {
            Console.WriteLine("Enter the meal number of the meal you want to delete");
            int num = int.Parse(Console.ReadLine());
            foreach (Menu item in _menu.GetMenu())
            {
                if(item.MealNumber == num)
                {
                    _menu.DeleteItem(item);
                    Console.WriteLine("Item Removed Successfully");
                    ToContinue();
                    return;
                }
            }
            Console.WriteLine("Item not found");
            ToContinue();
        }
        public void ShowMenu()
        {
            foreach(Menu item in _menu.GetMenu())
            {
                Console.WriteLine(item.MealNumber);
                Console.WriteLine(item.MealName);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.Ingredients);
                Console.WriteLine(item.Price);
                Console.WriteLine("---------------------------------");

            }
            ToContinue();
        }

    }
}
