using Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    class ProgramUI
    {
        protected readonly ClaimMethodRepo _repo = new ClaimMethodRepo();
        public void Run()
        {
            SeedClaimList();
            RunMenu();
        }
        public void RunMenu()
        {
            Console.WriteLine("\t\tWelcome to the Claims department. Here, we will review some of the claims submitted by our clients");
            bool shouldRun = true;
            while (shouldRun)
            {
                Console.SetWindowSize(170, 30);
                Console.Clear();
                Console.WriteLine("\t\tWelcome to the Claims department. Here, we will review some of the claims submitted by our clients\n" +
                    "\n" +
                    "\n" +
                    "\t\t1. Add claim\n" +
                    "\n" +
                    "\t\t2. Remove claim\n" +
                    "\n" +
                    "\t\t3. Update claim\n" +
                    "\n" +
                    "\t\t4. View all claims\n" +
                    "\n" +
                    "\t\t5. Close application");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //CreateClaim();
                        break;
                    case "2":
                        //DeleteClaim();
                        break;
                    case "3":
                        //UpdateClaim();
                        break;
                    case "4":
                       DisplayAll();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("                             Have a good day Admin.");
                        Console.ReadKey();
                        Environment.Exit(1);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("                             Enter 1-5 for your selection");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void DisplayAll()
        {
            Console.Clear();
            Console.WriteLine("ClaimID\t\tType\t\tDescription\t\t\tAmmount\t\tDateOfAccident\t\tDateOfClaim\t\tIsValid");
            List<Claim> claims = _repo.GetClaims();
            foreach(Claim claim in claims)
            {
                string isValid = "false";
                if (claim.IsValid)
                {
                    isValid = "true";
                }
                string dateOfAccident = ($"{claim.DateOfIncident.Month}/{claim.DateOfIncident.Day}/{claim.DateOfIncident.Year}");
                string dateOfClaim = ($"{claim.DateOfClaim.Month}/{claim.DateOfClaim.Day}/{claim.DateOfClaim.Year}");
                Console.WriteLine($"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description}\t{claim.ClaimAmmount}\t{dateOfAccident}\t{dateOfClaim}\t{isValid}");
                //Console.WriteLine("{0,1}, {1,0}, {2,20}, {3,20}, {4,20}, {5,20}", claim.ClaimID, claim.ClaimType, claim.Description, claim.ClaimAmmount, dateOfAccident, dateOfClaim);
            }
            Console.ReadKey();
        }
        public void SeedClaimList()
        {
            Claim claim1 = new Claim(1, TypeClaim.Car, "The Car was consumed...", 16000, new DateTime(2015,08,15), new DateTime(2015,08,04));
            Claim claim2 = new Claim(1, TypeClaim.Home, "The home fell into the earth.", 20000, new DateTime(2000,04,12), new DateTime(2019,05,01));
            Claim claim3 = new Claim(1, TypeClaim.Theft, "My memory was stolen", 2, new DateTime(2021,11,03), new DateTime(2021,10,12));

            _repo.AddClaimToDir(claim1);
            _repo.AddClaimToDir(claim2);
            _repo.AddClaimToDir(claim3);
        }
    }
}
