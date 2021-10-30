using SmartInsurance_MethodReposotory;
using SmartInsureanceMethodReposotory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInsurance_Console
{
    class ProgramUI
    {
        protected readonly DriverMethodRepo _repo = new DriverMethodRepo();
        public void Run()
        {
            SeedDriverList();
            RunMenu();
        }
        public void RunMenu()
        {
            bool shouldRun = true;
            while (shouldRun)
            {
                Console.Clear();
                Console.WriteLine("\t\tHello, Komodo... it's time to do some stuff.\n" +
                    "\t\tSelect fromm the following to get started.\n" +
                    "\n" +
                    "\t\t\t1. Add client\n" +
                    "\n" +
                    "\t\t\t2. Remove client\n" +
                    "\n" +
                    "\t\t\t3. Update client information\n" +
                    "\n" +
                    "\t\t\t4. View all clients");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        CreateDriver();
                        break;
                    case "2":
                        Console.Clear();
                        DeleteDriver();
                        break;
                    case "3":
                        Console.Clear();
                        //UpdateDriver
                        break;
                    case "4":
                        Console.Clear();
                        ViewDrivers();
                        break;
                }
            }
        }
        public void CreateDriver()
        {
            Console.Clear();
            Driver driver = new Driver();
            Console.WriteLine("What is the first name of the driver?");
            driver.FirstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Okay, the driver's first name is: {driver.FirstName}");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"What is {driver.FirstName}'s last name?");
            driver.LastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Okay, {driver.FirstName}'s last name is: {driver.LastName}");
            Console.ReadKey();
            Console.Clear();

            bool runPremium = true;
            while (runPremium)
            {
                Console.Clear();
                Console.WriteLine($"What is {driver.FirstName} {driver.LastName}'s starting premium?");
                double input;
                bool parse = double.TryParse(Console.ReadLine(), out input);
                if (parse)
                {
                    driver.Premium = input;
                    Console.WriteLine($"Okay, {driver.FirstName} {driver.LastName}'s starting premium is: ${driver.Premium}");
                    Console.ReadKey();
                    Console.Clear();
                    runPremium = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            bool metaID = true;
            bool runID = true;
            while (runID)
            {
                while (metaID)
                {
                    bool idExists = false;
                    Console.Clear();
                    Console.WriteLine($"What is {driver.FirstName} {driver.LastName}'s ID?");
                    int tryID = 0;
                    string input = Console.ReadLine();
                    try
                    {
                        tryID = int.Parse(input);
                        foreach (Driver checkID in _repo.GetDrivers())
                        {
                            if (checkID.DriverID == tryID)
                            {
                                Console.WriteLine($"Sorry a driver with that ID already exists ({checkID.FirstName})");
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
                        driver.DriverID = tryID;
                        Console.WriteLine($"Okay, {driver.FirstName} {driver.LastName}'s ID is {driver.DriverID}.\n" +
                            $"Press any key to continue.");
                        Console.ReadKey();
                        metaID = false;
                        runID = false;
                    }
                    Console.Clear();
                    Driver experiencedDriver = _repo.GenerateHabbits(driver);
                    Console.WriteLine("After 6 months...");
                    Console.ReadKey();
                    Console.Clear();

                    double initialPremium = driver.Premium;
                    int badHabbitCount = experiencedDriver.BadHabbits.Count();
                    int goodHabbitCount = experiencedDriver.GoodHabbits.Count();
                    experiencedDriver.Premium =  _repo.CalculatePremiumByHabbit(experiencedDriver);
                    double updatedPremium = experiencedDriver.Premium;

                    Console.WriteLine($"Over the months it seems {experiencedDriver.FirstName} {experiencedDriver.LastName} had developed " +
                        $"{goodHabbitCount} good habbit(s), and {badHabbitCount} bad habbit(s)");

                    if (initialPremium > updatedPremium)
                    {
                        Console.WriteLine($"Due to this, {driver.FirstName}'s premium has been lowered by ${(int)initialPremium - updatedPremium}!");
                    }
                    if (initialPremium < updatedPremium)
                    {
                        Console.WriteLine($"Due to this, {driver.FirstName}'s premium has been rased by ${(int)updatedPremium - initialPremium}.");
                    }
                    if (initialPremium == updatedPremium)
                    {
                        Console.WriteLine("This does not affect their premium.");
                    }
                    Console.ReadKey();
                    _repo.AddDriverToDir(experiencedDriver);
                }
            }
        }
        public void DeleteDriver()
        {
            List<Driver> driverList = _repo.GetDrivers();
            int customerCheck = driverList.Count;
            if (customerCheck > 0)
            {
                bool runID = true;
                while (runID)
                {
                    Console.Clear();
                    Console.WriteLine("Please input the ID of the client you would like to remove.");
                    int input;
                    bool parse = int.TryParse(Console.ReadLine(), out input);
                    if (parse)
                    {
                        Driver driverToRemove = _repo.GetDriverByID(input);
                        if (_repo.RemoveDriverFromDir(driverToRemove))
                        {
                            Console.WriteLine("client removed.");
                            Console.ReadKey();
                            runID = false;
                        }
                        else
                        {
                            Console.WriteLine($"None of our clients have an ID of {input}\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            runID = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("please enter a valid number");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no clients to remove!");
            }

        }
        public void UpdateDriver()
        {
            List<Driver> driverList = _repo.GetDrivers();
            int customerCheck = driverList.Count;
            if (customerCheck > 0)
            {
                bool runID = true;
                while (runID)
                {
                    Console.Clear();
                    Console.WriteLine("Please input the ID of the client you would like to update.");
                    int input;
                    bool parse = int.TryParse(Console.ReadLine(), out input);
                    if (parse)
                    {

                        Console.Clear();
                        Driver driver = new Driver();
                        Console.WriteLine("What is the first name of the driver?");
                        driver.FirstName = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Okay, the driver's first name is: {driver.FirstName}");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine($"What is {driver.FirstName}'s last name?");
                        driver.LastName = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Okay, {driver.FirstName}'s last name is: {driver.LastName}");
                        Console.ReadKey();
                        Console.Clear();

                        bool runPremium = true;
                        while (runPremium)
                        {
                            Console.Clear();
                            Console.WriteLine($"What is {driver.FirstName} {driver.LastName}'s starting premium?");
                            double updatInput;
                            bool check = double.TryParse(Console.ReadLine(), out updatInput);
                            if (check)
                            {
                                driver.Premium = input;
                                Console.WriteLine($"Okay, {driver.FirstName} {driver.LastName}'s starting premium is: ${driver.Premium}");
                                Console.ReadKey();
                                Console.Clear();
                                runPremium = false;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid number.");
                                Console.ReadKey();
                            }
                        }



                        Driver driverToUpdate = _repo.GetDriverByID(input);
                        if (_repo.RemoveDriverFromDir(driverToUpdate))
                        {
                            Console.WriteLine("client updated");
                            Console.ReadKey();
                            runID = false;
                        }
                        else
                        {
                            Console.WriteLine($"None of our clients have an ID of {input}\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            runID = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("please enter a valid number");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no clients to remove!");
            }
        }
        public void ViewDrivers()
        {
            Console.Clear();
            foreach(Driver driver in _repo.GetDrivers())
            {
                Console.WriteLine($"\t\t{driver.FirstName} {driver.LastName}\tPremium cost: ${driver.Premium}\n");
            }
            Console.ReadKey();
        }
        public void SeedDriverList()
        {
            Driver driver1 = new Driver(1, "Jhon", "Smith", 500);
            Driver driver2 = new Driver(2, "James", "Smitten", 500);
            Driver driver3 = new Driver(3, "Cathy", "Salson", 500);
            Driver driver4 = new Driver(4, "Marcus", "Phenox", 500);

            _repo.AddDriverToDir(driver1);
            _repo.AddDriverToDir(driver2);
            _repo.AddDriverToDir(driver3);
            _repo.AddDriverToDir(driver4);
        }
    }
}
