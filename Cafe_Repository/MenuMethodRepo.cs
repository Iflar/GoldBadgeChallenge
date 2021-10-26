using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class MenuMethodRepo
    {
        protected readonly List<Menu> _menuDirectory = new List<Menu>();
        protected readonly List<Menu> _orderDirectory = new List<Menu>();
        
        public bool AddMenuItemToDir(Menu menuItem)
        {
            int start = _menuDirectory.Count;
            _menuDirectory.Add(menuItem);
            bool done = _menuDirectory.Count > start ? true : false;
            return false;
        }
        public bool AddItemToOrder(int orderNum)
        {
            int start = _menuDirectory.Count;
            foreach (Menu item in _menuDirectory)
            {
                if (item.OrderNum == orderNum)
                {
                    _orderDirectory.Add(item);
                }
            }
            bool done = _orderDirectory.Count > start ? true : false;
            return false;
        }
        public bool RemoveItemFromOrder(int orderNum)
        {
            int start = _menuDirectory.Count;
            int orderCheck = _orderDirectory.Count();
            if (orderCheck == 0)
            {
                return false;
            }
            foreach (Menu item in _menuDirectory)
            {
                if (item.OrderNum == orderNum)
                {
                    _orderDirectory.Remove(item);
                }
            }
            bool done = _orderDirectory.Count < start ? true : false;
            return false;
        }
        public bool RemoveMenuItemFromDir(Menu menuItem)
        {
            int start = _menuDirectory.Count;
            _menuDirectory.Remove(menuItem);
            bool done = _menuDirectory.Count < start ? true : false;
            return false;
        }
        public bool UpdateMenuItem(int orderNum, Menu newOrder)
        {
            Menu oldOrder = GetOrderByNumber(orderNum);
            if (oldOrder != null)
            {
                oldOrder.Name = newOrder.Name;
                oldOrder.OrderNum = newOrder.OrderNum;
                oldOrder.Price = newOrder.Price;
                oldOrder.ListOfIngredients = newOrder.ListOfIngredients;
                oldOrder.Discription = newOrder.Discription;
                Console.WriteLine("Order updated");
                return true;
            }
            return false;
        }
        public List<Menu> GetAllMenus()
        {
            return _menuDirectory;
        }
        public List<Menu> GetAllOrders()
        {
            return _orderDirectory;
        }
        public Menu GetOrderByNumber(int orderNum)
        {
            foreach(Menu item in _orderDirectory)
            {
                if (item.OrderNum == orderNum)
                {
                    return item;
                }
            }
            return null;
        }
        public Menu GetMenuItemByIndex(int indexNum)
        {
            if (indexNum < 6)
            {
                return _menuDirectory[indexNum];
            }
            return null;
        }
        public void DisplayIngredience(int itemNum)
        {
            foreach (Menu item in _menuDirectory)
            {
                if (item.OrderNum == itemNum)
                {
                    int count = 1;
                    foreach (Ingredients ingredient in item.ListOfIngredients)
                    {
                        int eVal = ((int)ingredient);
                        var eName = (Ingredients)eVal;
                        Console.WriteLine($"{count}. {eName}");
                        ++count;
                    }
                    Console.WriteLine(item.Discription);
                }
            }
        }
    }
}
