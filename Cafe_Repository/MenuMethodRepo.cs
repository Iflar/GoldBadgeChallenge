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
        public bool UpdateMenuItem()
        {

            return false;
        }
        public List<Menu> GetAllMenus()
        {
            return _menuDirectory;
        }
    }
}
