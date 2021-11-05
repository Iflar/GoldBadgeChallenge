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
                        CreateClaim();
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
                        Console.WriteLine("                             Have a good day. Always be daring!");
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
        public void CreateClaim()
        {

            Console.Clear();

            Claim claim = new Claim();
            
            bool runTypeLoop = true;
            while (runTypeLoop)
            {
                Console.WriteLine("What is the claim type?\n" +
                    "1. Car\n" +
                    "2. Home\n" +
                    "3. Theft\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        claim.ClaimType = TypeClaim.Car;
                    runTypeLoop = false;
                        break;
                    case "2":
                        claim.ClaimType = TypeClaim.Home;
                        runTypeLoop = false;
                        break;
                    case "3":
                        claim.ClaimType = TypeClaim.Theft;
                        runTypeLoop = false;
                        break;
                }
            }

            Console.Clear();

            Console.WriteLine("Please give a brief discription of the incident");
            claim.Description = Console.ReadLine();

            Console.Clear();

            bool runDate1 = true;
            while (runDate1)
            {
                Console.Clear();
                Console.WriteLine("When did the incident occur?\n" +
                "(yyyy,mm,dd)");
                string input = Console.ReadLine();
                try
                {
                    claim.DateOfIncident = DateTime.Parse(input);
                    runDate1 = false;
                }
                catch
                {
                    Console.WriteLine("Please fill out the correct format: yyyy,mm,dd\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                }
            }

            bool runDate2 = true;
            while (runDate2)
            {
                Console.Clear();
                Console.WriteLine("when was the claim made?\n" +
                "(yyyy,mm,dd)");
                string input = Console.ReadLine();
                try
                {
                    claim.DateOfClaim = DateTime.Parse(input);
                    
                    runDate2 = false;
                }
                catch
                {
                    Console.WriteLine("Please fill out the correct format: yyyy,mm,dd\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                }
            }

            bool metaID = true;
            bool runID = true;
            while (runID)
            {
                while (metaID)
                {
                    bool idExists = false;
                    Console.Clear();
                    Console.WriteLine("What is the ClaimID?");
                    int tryID = 0;
                    string input = Console.ReadLine();
                    try
                    {
                        tryID = int.Parse(input);
                        foreach (Claim checkID in _repo.GetClaims())
                        {
                            if (checkID.ClaimID == tryID)
                            {
                                Console.WriteLine("Sorry a Claim with that ID already exists");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                idExists = true;
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a vild number\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                    }
                    if (!idExists)
                    {
                        claim.ClaimID = tryID;
                        _repo.AddClaimToDir(claim);
                        Console.WriteLine($"Claim added");
                        Console.ReadKey();
                        metaID = false;
                        runID = false;
                    }
                }

            }

        }
        public void DisplayAll()
        {
            Console.Clear();
            Console.WriteLine("ClaimID\t\tType\t\tDescription\t\t\tAmmount\t\tDateOfAccident\t\tDateOfClaim\t\tIsValid");
            List<Claim> claims = _repo.GetClaims();

            foreach (Claim claim in claims)
            {
                string isValid = "false";
                if (claim.IsValid)
                {
                    isValid = "true";
                }
                string dateOfAccident = ($"{claim.DateOfIncident.Month}/{claim.DateOfIncident.Day}/{claim.DateOfIncident.Year}");
                string dateOfClaim = ($"{claim.DateOfClaim.Month}/{claim.DateOfClaim.Day}/{claim.DateOfClaim.Year}");


                Console.WriteLine($"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description}\t{claim.ClaimAmmount}\t{dateOfAccident}\t{dateOfClaim}\t{isValid}");

            }
            Console.ReadKey();
        }
        public void SeedClaimList()
        {
            Claim claim1 = new Claim(1, TypeClaim.Car, "The Car was consumed...", 16000, new DateTime(2015, 08, 04), new DateTime(2015, 08, 15));
            Claim claim2 = new Claim(2, TypeClaim.Home, "The home fell into the earth.", 20000, new DateTime(2000, 04, 12), new DateTime(2019, 05, 01));
            Claim claim3 = new Claim(3, TypeClaim.Theft, "My memory was stolen", 2, new DateTime(2021, 11, 03), new DateTime(2021, 10, 12));

            _repo.AddClaimToDir(claim1);
            _repo.AddClaimToDir(claim2);
            _repo.AddClaimToDir(claim3);
        }
    }
}
