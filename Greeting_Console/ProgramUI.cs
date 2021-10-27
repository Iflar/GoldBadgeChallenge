using Greeting_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Console
{
    class ProgramUI
    {
        //new DateTime(2001, 03, 24);
        protected readonly CustomerMethodRepo _repo = new CustomerMethodRepo();
        public void Run()
        {
            SeedCustomerList();
            RunMenu();
        }
        public void RunMenu()
        {
            bool shouldRun = true;
            while (shouldRun)
            {
                Console.Clear();
                Console.WriteLine("             Welcome Administrator, what would you like to do today?\n" +
                    "\n" +
                    "\n" +
                    "                       1. Add customer\n" +
                    "\n" +
                    "                       2. Remove customer\n" +
                    "\n" +
                    "                       3. Update customer infromation\n" +
                    "\n" +
                    "                       4. View list of customers and emails sent out to them.\n" +
                    "\n" +
                    "                       5. Close application");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateCustomer();
                        break;
                    case "2":
                        RemoveCustomer();
                        break;
                    case "3":
                        UpdateCustomer();
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
        public void CreateCustomer()
        {
            Console.Clear();

            Customer customer = new Customer();
            Console.WriteLine("What is their first name?");
            customer.FirstName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("And their last name?");
            customer.LastName = Console.ReadLine();

            Console.Clear();

            bool runDate = true;
            while (runDate)
            {
                Console.Clear();
                Console.WriteLine("What is today's date?\n" +
                "(yyyy,mm,dd)");
                string input = Console.ReadLine();
                try
                {
                    customer.DateActive = DateTime.Parse(input);
                    runDate = false;
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
                    Console.WriteLine("What is the CustomerID?");
                    int tryID = 0;
                    string input = Console.ReadLine();
                    try
                    {
                        tryID = int.Parse(input);
                        foreach (Customer checkID in _repo.GetAllCustomers())
                        {
                            if (checkID.CustomerID == tryID)
                            {
                                Console.WriteLine("Sorry a customer with that ID already exists");
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
                        customer.CustomerID = tryID;
                        _repo.AddCustomerToDir(customer);
                        Console.WriteLine($"Okay, {customer.FirstName} {customer.LastName}'s ID is {customer.CustomerID} and has been added to our database.\n" +
                            $"Press any key to continue.");
                        Console.ReadKey();
                        metaID = false;
                        runID = false;
                    }
                }

            }

        }
        public void RemoveCustomer()
        {
            List<Customer> customerList = _repo.GetAllCustomers();
            int customerCheck = customerList.Count;
            if (customerCheck > 0)
            {
                bool runID = true;
                while (runID)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the ID of the customer you would like to remove.");
                    int input;
                    bool parse = int.TryParse(Console.ReadLine(), out input);
                    if (parse)
                    {
                        Customer customerToRemove = _repo.GetCustomerByID(input);
                        if (_repo.RemoveCustomerFromDir(customerToRemove))
                        {
                            Console.WriteLine("Customer removed.");
                            Console.ReadKey();
                            runID = false;
                        }
                        else
                        {
                            Console.WriteLine($"None of our customers have an ID of {input}\n" +
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
                Console.WriteLine("There are no customers to remove.\n" +
                    "Press any key to continue");
                Console.ReadKey();

            }
        }
        public void UpdateCustomer()
        {
            List<Customer> customerList = _repo.GetAllCustomers();
            int customerCheck = customerList.Count;

            if (customerCheck > 0)
            {
                bool runUpdate = true;
                while (runUpdate)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the ID of the customer you would like to update.");
                    int input;
                    bool parse = int.TryParse(Console.ReadLine(), out input);

                    bool idExists = false;
                    foreach (Customer customer in customerList)
                    {
                        if (customer.CustomerID == input)
                        {
                            idExists = true;
                        }
                    }
                    if (parse && idExists)
                    {
                        Console.Clear();
                        Console.WriteLine("Okay, let's make the changes\n" +
                            "Press any key to continue");
                        Console.ReadKey();

                        Console.Clear();

                        Customer newCustomer = new Customer();
                        Console.WriteLine("What is their new first name?");
                        newCustomer.FirstName = Console.ReadLine();

                        Console.Clear();

                        Console.WriteLine("And their last name?");
                        newCustomer.LastName = Console.ReadLine();

                        Console.Clear();

                        bool runDate = true;
                        while (runDate)
                        {
                            Console.Clear();
                            Console.WriteLine("When were they last active?\n" +
                            "(yyyy,mm,dd)");
                            string dateInput = Console.ReadLine();
                            try
                            {
                                newCustomer.DateActive = DateTime.Parse(dateInput);
                                _repo.UpdateCustomerInfo(input, newCustomer);
                                Console.WriteLine("Customer has been updated\n" +
                                    "Press any key to continue.");
                                Console.ReadKey();
                                runDate = false;
                                runUpdate = false;
                            }
                            catch
                            {
                                Console.WriteLine("Please fill out the correct format: yyyy,mm,dd\n" +
                                    "Press any key to continue");
                                Console.ReadKey();
                            }

                        }
                    }
                    else if (!idExists && parse)
                    {
                        Console.WriteLine($"None of our customers have an ID of {input}\n" +
                            $"Press any key to continue");
                        Console.ReadKey();
                        runUpdate = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number\n" +
                                    "Press any key to continue");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no customers to update.\n" +
                    "Press any key to continue");
                Console.ReadKey();
            }
            
        }
        public void DisplayAll()
        {
            Console.Clear();
            Console.WriteLine("FirstName\tLastName\tType\t\tEmail");
            foreach (Customer customer in _repo.GetAllCustomers())
            {
                MemberStatus type = customer.MemberStatus;
                int eVal = (int)type;
                var eName = (MemberStatus)eVal;

                string email = "";
                if (customer.MemberStatus == MemberStatus.Current)
                {
                    email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                }
                if (customer.MemberStatus == MemberStatus.Past)
                {
                    email = "It's been a long time sice we've heard from you, we want you back.";
                }
                if (customer.MemberStatus == MemberStatus.Potential)
                {
                    email = "We currently have the lowest rates on Helicopter Insurance!";
                }

                Console.WriteLine($"{customer.FirstName}\t\t{customer.LastName}\t\t{eName}\t\t{email}");

            }
            Console.ReadKey();
        }
        public void SeedCustomerList()
        {
            Customer customer1 = new Customer(1, "James", "Smith", new DateTime(1998, 04, 15));
            Customer customer2 = new Customer(2, "Chips", "Dubbo", new DateTime(2020, 12, 13));
            Customer customer3 = new Customer(3, "Avery", "Johnson", new DateTime(2021, 08, 29));
            Customer customer4 = new Customer(4, "Wallace", "Jenkins", null);

            _repo.AddCustomerToDir(customer1);
            _repo.AddCustomerToDir(customer2);
            _repo.AddCustomerToDir(customer3);
            _repo.AddCustomerToDir(customer4);
        }
    }
}
