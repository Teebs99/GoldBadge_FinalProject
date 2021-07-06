using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class ProgramUI
    {
        protected readonly CarRepo _repo = new CarRepo();

        public void Run()
        {
            SeedData();
            DisplayMenu();
        }
        public void SeedData()
        {
           Car electric = new Car("Tesla", "Roadster", CarType.Electric);
           Car gas = new Car("Pontiac", "G6", CarType.Gas);
           Car hybrid = new Car("Prius", "Model 1", CarType.Hybrid);
            _repo.AddCar(electric);
            _repo.AddCar(gas);
            _repo.AddCar(hybrid);
        }
        public void ToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Please select one of the following options\n" +
                    "1. Add new car\n" +
                    "2. Update car\n" +
                    "3. Delete car\n" +
                    "4. Show cars\n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        UpdateCar();
                        break;
                    case "3":
                        DeleteCar();
                        break;
                    case "4":
                        ShowCars();
                        break;
                    case "5":
                        running = false;
                        break;

                }
            }
        }
        public void AddCar()
        {
            Console.WriteLine("What is the Make of the Car");
            string make = Console.ReadLine();
            Console.WriteLine("What is the Model of the Car");
            string model = Console.ReadLine();
            Console.WriteLine("Select the type of car\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas");
            CarType type = (CarType)int.Parse(Console.ReadLine()) - 1;
            _repo.AddCar(new Car(make, model, type));
            ToContinue();
        }
        public void UpdateCar()
        {
            Console.WriteLine("Enter the make and model of the car");
            string[] oldCarInfo = Console.ReadLine().Split(' ');
            Car oldCar = _repo.GetCar(oldCarInfo[0], oldCarInfo[1]);
            Console.WriteLine("Enter the updated make and model");
            string[] updatedInfo = Console.ReadLine().Split(' ');
            Console.WriteLine("Select the type of car\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas");
            CarType type = (CarType)int.Parse(Console.ReadLine()) - 1;
            _repo.UpdateCar(oldCar, new Car(updatedInfo[0], updatedInfo[1], type));
            ToContinue();
        }
        public void DeleteCar()
        {
            Console.WriteLine("Enter the make and model of the car to be deleted");
            string[] carInfo = Console.ReadLine().Split(' ');
            _repo.DeleteCar(_repo.GetCar(carInfo[0], carInfo[1]));
            ToContinue();
        }
        public void ShowCars()
        {
            Console.WriteLine("Select one of the following options\n" +
                "1. All Cars\n" +
                "2. Electric Cars\n" +
                "3. Hybrid Cars\n" +
                "4. Gas Cars");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    foreach(Car car in _repo.GetAllCars())
                    {
                        Console.WriteLine($"{car.Make} {car.Model} {car.CarType}");
                        
                    }
                    ToContinue();
                    break;
                case "2":
                    foreach (Car car in _repo.GetElectric())
                    {
                        Console.WriteLine($"{car.Make} {car.Model} {car.CarType}");
                        
                    }
                    ToContinue();
                    break;
                case "3":
                    foreach (Car car in _repo.GetHybrid())
                    {
                        Console.WriteLine($"{car.Make} {car.Model} {car.CarType}");
                        
                    }
                    ToContinue();
                    break;
                case "4":
                    foreach (Car car in _repo.GetGas())
                    {
                        Console.WriteLine($"{car.Make} {car.Model} {car.CarType}");
                        
                    }
                    ToContinue();
                    break;
            }

        }

    }
}
