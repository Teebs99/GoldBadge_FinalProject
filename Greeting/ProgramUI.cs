using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    class ProgramUI
    {
        protected readonly CustomerRepo _customer = new CustomerRepo();
        public void Run()
        {
            SeedData();
            DisplayMenu();
            
        }
        public void SeedData()
        {
            Customer a = new Customer("Kyle", "Smith", GreetingType.Current);
            Customer b = new Customer("Johnny", "Appleseed", GreetingType.Potential);
            Customer c = new Customer("Chris", "Black", GreetingType.Past);
            _customer.AddCustomer(a);
            _customer.AddCustomer(b);
            _customer.AddCustomer(c);


        }
        public void DisplayMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Please select one of the following options\n" +
                    "1. Add new customer\n" +
                    "2. Update Customer\n" +
                    "3. Delete Customer\n" +
                    "4. Show customers\n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        UpdateCustomer();
                        break;
                    case "3":
                        DeleteCustomer();
                        break;
                    case "4":
                        ShowCustomers();
                        break;
                    case "5":
                        running = false;
                        break;

                }
            }
        }
        public void AddCustomer()
        {
            Console.WriteLine("What is the customer's first name?");
            string fname = Console.ReadLine();
            Console.WriteLine("What is the customer's last name");
            string lname = Console.ReadLine();
            Console.WriteLine("What is the status of the customer?\n" +
                "1. Potential\n" +
                "2. Past\n" +
                "3. Current");
            GreetingType type = (GreetingType)int.Parse(Console.ReadLine())-1;
            _customer.AddCustomer(new Customer(fname, lname, type));
            ToContinue();
        }
        public void UpdateCustomer()
        {
            Console.WriteLine("Enter the first and last name of the customer you wish to update");
            string[] name = Console.ReadLine().Split(' ');
            Customer oldCustomer = _customer.GetCustomerByName(name[0], name[1]);
            Console.WriteLine("What is the new first name");
            string fname = Console.ReadLine();
            Console.WriteLine("What is the new last name");
            string lname = Console.ReadLine();
            Console.WriteLine("What is the status of the customer?\n" +
                "1. Potential\n" +
                "2. Past\n" +
                "3. Current");
            GreetingType type = (GreetingType)int.Parse(Console.ReadLine())-1;
            _customer.UpdateCustomer(oldCustomer, new Customer(fname, lname, type));
            ToContinue();
            
        }
        public void DeleteCustomer()
        {
            Console.WriteLine("Enter the first and last name of the customer you wish to delete");
            string[] name = Console.ReadLine().Split(' ');
            Customer customer = _customer.GetCustomerByName(name[0], name[1]);
            _customer.DeleteCustomer(customer);
            ToContinue();
        }
        public void ShowCustomers()
        {
            foreach(Customer customer in _customer.GetCustomers())
            {
                Console.WriteLine(customer.FirstName + " " + customer.LastName + " " + customer.CustomerType + " " + customer.Email);
            }
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
