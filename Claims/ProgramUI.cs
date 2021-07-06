using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    class ProgramUI
    {
        protected readonly ClaimRepo _claims = new ClaimRepo();

        public void SeedContent()
        {
            Claim claim1 = new Claim(1, ClaimType.Car, "Car Accident on 465", 400.00d, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim claim2 = new Claim(2, ClaimType.Home, "House Fire in kitchen", 4000.00d, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen Pancakes", 4.00d, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));
            _claims.AddClaim(claim1);
            _claims.AddClaim(claim2);
            _claims.AddClaim(claim3);


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
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        ShowClaims();
                        break;
                    case "2":
                        HandleClaim();
                        break;
                    case "3":
                        AddClaim();
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

        public void AddClaim()
        {
            Console.WriteLine("Enter the claim number");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Select the claim type\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string type = Console.ReadLine();
            ClaimType claimType = (ClaimType)int.Parse(type);
            Console.WriteLine("Enter the claim description");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter the claim amount");
            double amount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the month the incident happened");
            int imonth = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the day the incident happened");
            int iday = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the year the incident happened");
            int iyear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the month of the claim");
            int cmonth = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the day of the claim");
            int cday = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the year of the claim");
            int cyear = int.Parse(Console.ReadLine());
            Claim claim = new Claim(number, claimType, desc, amount, new DateTime(iyear, imonth, iday), new DateTime(cyear, cmonth, cday));
            _claims.AddClaim(claim);
            ToContinue();
        }
        public void HandleClaim()
        {
            Queue<Claim> claims = _claims.GetClaims();
            Claim claim = claims.Peek();
            Console.WriteLine(claim.ClaimId);
            Console.WriteLine(claim.ClaimType);
            Console.WriteLine(claim.Description);
            Console.WriteLine("$" + claim.ClaimAmount);
            Console.WriteLine(claim.DateOfIncident.ToShortDateString());
            Console.WriteLine(claim.DateOfClaim.ToShortDateString());
            Console.WriteLine(claim.IsValid);
            Console.WriteLine("Do you want to deal with this claim now? y/n");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "y")
            {
                _claims.NextClaim();
                ToContinue();
            }

            Console.Clear();


        }
        public void ShowClaims()
        {
            Console.WriteLine("Id\tType\tDescription\t\tAmount\t Incident\tClaim\t\tIsValid");
            Queue<Claim> claims = new Queue<Claim>();
            claims = _claims.GetClaims();
            while (claims.Count > 0)
            {
                ShowClaim(claims.Dequeue());
            }
            ToContinue();
        }
        public void ShowClaim(Claim claim)
        {
            //Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", claim.ClaimId + "\t" + claim.ClaimType + "\t" + claim.Description + "\t$" + claim.ClaimAmount + "\t" + claim.DateOfIncident.ToShortDateString() + "\t" + claim.DateOfClaim.ToShortDateString() + "\t" + claim.IsValid); ;
            Console.WriteLine("{0,-8}{1,-8}{2,-25}{3,-8}{4,-15}{5,-15}{6,-15}", claim.ClaimId, claim.ClaimType,claim.Description,"$"+claim.ClaimAmount,claim.DateOfIncident.ToShortDateString(),claim.DateOfClaim.ToShortDateString()," " +claim.IsValid); ;
        }
    }
}
