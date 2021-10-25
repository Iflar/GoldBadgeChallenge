using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public enum Ingredients
    {
        Water,
        Chocolate,
        Beans,
        Egg,
        Bread,
        Salt,
        Pepper,
        Spaghetti,
        Sause
    }
    public class Menu
    {
        public double Price { get; set; }
        public string Name  { get; set; }
        public string Discription { get; set; }
        public int OrderNum { get; set; }
        public List<Ingredients> ListOfIngredients { get; set; }

        public Menu()
        {
            ListOfIngredients = new List<Ingredients>();
        }

        public Menu(double price, string name, string discription, int orderNum)
        {
            Price = price;
            Name = name;
            Discription = discription;
            OrderNum = orderNum;
            ListOfIngredients = new List<Ingredients>();
        }
    }
}
