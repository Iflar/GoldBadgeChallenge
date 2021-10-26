using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_ConsoleApp
{
    public class ProgramUI
    {
        protected readonly MenuMethodRepo _menuRepo = new MenuMethodRepo();
        public void Run()
        {
            CreateMenuItems();
            RunMenu();
        }


        public void RunMenu()
        {
            bool shouldRun = true;
            while (shouldRun)
            {
                Console.Clear();
                Console.WriteLine("        Welcome to our Cafe!\n" +
                    "Choose from the following options below to get started.\n" +
                    "1. Place Order\n" +
                    "2. View ingredients of menu items\n" +
                    "3. Cancel Order\n" +
                    "4. Update order \n" +
                    "5. View menu\n" +
                    "6.         --Leave Cafe--");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddItemToOrder();
                        break;
                    case "2":
                        DisplayIngredients();
                        break;
                    case "3":
                        CancelOrder();
                        break;
                    case "4":
                        UpdateOrder();
                        break;
                    case "5":
                        DisplayMenu();
                        break;
                    case "6":
                        Console.WriteLine("Sorry to see you go... Have a nice day - and we'll see you next time!");
                        Console.ReadKey();
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Enter 1-5 for your selection");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void AddItemToOrder()
        {
            Console.Clear();
            List<Menu> menu = _menuRepo.GetAllMenus();
            List<Menu> orderTab = _menuRepo.GetAllOrders();
            int orderCheck = orderTab.Count();

            if (orderCheck < 1)
            {
                Console.WriteLine("What would you like to order?");
                int count = 1;
                foreach (Menu item in menu)
                {
                    Console.WriteLine($"#{count}. {item.Name}");
                    ++count;
                }
                bool ordering = true;
                while (ordering)
                {
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            _menuRepo.AddItemToOrder(1);
                            Console.WriteLine($"Number 1 coming right up\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            ordering = false;
                            break;
                        case "2":
                            _menuRepo.AddItemToOrder(2);
                            Console.WriteLine($"Number 2 coming right up\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            ordering = false;
                            break;
                        case "3":
                            _menuRepo.AddItemToOrder(3);
                            Console.WriteLine($"Number 3 coming right up\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            ordering = false;
                            break;
                        case "4":
                            _menuRepo.AddItemToOrder(4);
                            Console.WriteLine($"Number 4 coming right up\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            ordering = false;
                            break;
                        case "5":
                            _menuRepo.AddItemToOrder(5);
                            Console.WriteLine($"Number 5 coming right up\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            ordering = false;
                            break;
                        default:
                            Console.WriteLine("Please select from our options: 1-5");
                            break;
                    }

                }

            }
            else
            {
                Console.WriteLine("It looks like you already have an order.\n" +
                    "               Press any key to continue");
                Console.ReadKey();

            }

        }
        public void CreateMenuItems()
        {
            Menu itemOne = new Menu(24.07, "Expensive Coffee", "Little is known of this coffee, exept for the fact that it is very expensive.", 1);
            Menu itemTwo = new Menu(5.99, "Egggg sandwitch", "This is a very elegantly crafted sandwitch that is totally worth the money.", 2);
            Menu itemThree = new Menu(2.39, "Water", "You can get water anywhere for free, but just wait untill you have ours.", 3);
            Menu itemFour = new Menu(8.99, "Baguehetti", "Bread, sause, and noodles expertly baked together with French and Itallian guidance.", 4);
            Menu itemFive = new Menu(0.28, "Chocolate egg", "A hard boild egg dipped in dark chocolate from the south of Brazil - frozen solid.", 5);

            itemOne.ListOfIngredients.Add(Ingredients.Beans);
            itemOne.ListOfIngredients.Add(Ingredients.Water);

            itemTwo.ListOfIngredients.Add(Ingredients.Egg);
            itemTwo.ListOfIngredients.Add(Ingredients.Bread);
            itemTwo.ListOfIngredients.Add(Ingredients.Salt);
            itemTwo.ListOfIngredients.Add(Ingredients.Pepper);

            itemThree.ListOfIngredients.Add(Ingredients.Water);

            itemFour.ListOfIngredients.Add(Ingredients.Bread);
            itemFour.ListOfIngredients.Add(Ingredients.Spaghetti);
            itemFour.ListOfIngredients.Add(Ingredients.Sause);

            itemFive.ListOfIngredients.Add(Ingredients.Egg);
            itemFive.ListOfIngredients.Add(Ingredients.Chocolate);

            _menuRepo.AddMenuItemToDir(itemOne);
            _menuRepo.AddMenuItemToDir(itemTwo);
            _menuRepo.AddMenuItemToDir(itemThree);
            _menuRepo.AddMenuItemToDir(itemFour);
            _menuRepo.AddMenuItemToDir(itemFive);
        }
        public void UpdateOrder()
        {
            List<Menu> menu = _menuRepo.GetAllMenus();
            List<Menu> orderTab = _menuRepo.GetAllOrders();
            int orderCheck = orderTab.Count();

            int orderNum = 0;
            foreach (Menu item in orderTab)
            {
                orderNum = item.OrderNum;
            }
            if (orderNum > 0)
            {
                Console.WriteLine("what would you like the new order to be?");
                int count = 1;
                foreach (Menu item in menu)
                {
                    Console.WriteLine($"#{count}. {item.Name}");
                    ++count;
                }
                bool ordering = true;
                Menu newOrder = new Menu();
                while (ordering)
                {
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            newOrder = _menuRepo.GetMenuItemByIndex(1);
                            _menuRepo.UpdateMenuItem(orderNum, newOrder);
                            Console.WriteLine($"Number 1 coming right up\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            ordering = false;
                            break;
                        case "2":
                            newOrder = _menuRepo.GetMenuItemByIndex(2);
                            _menuRepo.UpdateMenuItem(orderNum, newOrder);
                            Console.WriteLine($"Number 2 coming right up\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            ordering = false;
                            break;
                        case "3":
                            newOrder = _menuRepo.GetMenuItemByIndex(3);
                            _menuRepo.UpdateMenuItem(orderNum, newOrder);
                            Console.WriteLine($"Number 3 coming right up\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            ordering = false;
                            break;
                        case "4":
                            newOrder = _menuRepo.GetMenuItemByIndex(4);
                            _menuRepo.UpdateMenuItem(orderNum, newOrder);
                            Console.WriteLine($"Number 4 coming right up\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            ordering = false;
                            break;
                        case "5":
                            newOrder = _menuRepo.GetMenuItemByIndex(5);
                            _menuRepo.UpdateMenuItem(orderNum, newOrder);
                            Console.WriteLine($"Number 5 coming right up\n" +
                                $"Press any key to continue");
                            Console.ReadKey();
                            ordering = false;
                            break;
                        default:
                            Console.WriteLine("Please select from our options: 1-5");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no order to update.\n" +
                    "               Press any key to continue.");
                Console.ReadKey();
            }
        }
        public void CancelOrder()
        {
            bool proceed = false;
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Are you sure you want to cancel the order?\n" +
                "1. Yes\n" +
                "2. No");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        proceed = true;
                        run = false;
                        break;
                    case "2":
                        Console.WriteLine("Okay, we'll have the order ready soon!");
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Select 1 or 2");
                        break;
                }
            }
            if (proceed)
            {
                List<Menu> orderList = _menuRepo.GetAllOrders();
                orderList.Clear();
                Console.WriteLine("Okay, your order has been canceled.\n" +
                    "               Press any key to continue");
                Console.ReadKey();
            }
        }
        public void DisplayMenu()
        {
            Console.Clear();
            List<Menu> menu = _menuRepo.GetAllMenus();
            int count = 1;
            foreach (Menu item in menu)
            {
                Console.WriteLine($"#{count}. {item.Name}");
                ++count;
            }
            Console.WriteLine("             Press Enter to go back");
            Console.ReadKey();
        }
        public void DisplayIngredients()
        {
            Console.Clear();
            List<Menu> menu = _menuRepo.GetAllMenus();
            int count = 1;
            bool ordering = true;
            while (ordering)
            {
                Console.WriteLine("what would you like to see?");
                foreach (Menu item in menu)
                {
                    Console.WriteLine($"#{count}. {item.Name}");
                    ++count;
                }
                Console.WriteLine("Press 6 to go back");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        _menuRepo.DisplayIngredience(1);
                        Console.ReadKey();
                        Console.Clear();
                        count = 1;
                        break;
                    case "2":
                        Console.Clear();
                        _menuRepo.DisplayIngredience(2);
                        Console.ReadKey();
                        Console.Clear();
                        count = 1;
                        break;
                    case "3":
                        Console.Clear();
                        _menuRepo.DisplayIngredience(3);
                        Console.ReadKey();
                        Console.Clear();
                        count = 1;
                        break;
                    case "4":
                        Console.Clear();
                        _menuRepo.DisplayIngredience(4);
                        Console.ReadKey();
                        Console.Clear();
                        count = 1;
                        break;
                    case "5":
                        Console.Clear();
                        _menuRepo.DisplayIngredience(5);
                        Console.ReadKey();
                        Console.Clear();
                        count = 1;
                        break;
                    case "6":
                        Console.Clear();
                        ordering = false;
                        break;
                    default:
                        Console.WriteLine("Please select from our options: 1-5");
                        Console.Clear();
                        count = 1;
                        break;
                }

            }
        }
    }
}
