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
                    "4.         --Leave Cafe--");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        Console.WriteLine("Sorry to see you go... Have a nice day - and we'll see you next time!");
                        Console.ReadKey();
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Enter 1-4 for your selection");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void CreateMenuItems()
        {
            Menu itemOne = new Menu(24.07, "Expensive Coffee", "Little is known of this coffee, exept for the fact that it is very expensive.", 1);
            Menu itemTwo = new Menu(5.99, "Egggg sandwitch", "This is a very elegantly crafted sandwitch that is totally worth the money.", 2);
            Menu itemThree = new Menu(2.39, "Water", "You can get water anywhere for free, but just wait untill you have ours.", 3);
            Menu itemFour = new Menu(8.99, "baguehetti", "Bread, sause, and noodles expertly baked together with French and Itallian guidance.", 4);
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

        }
    }
}
