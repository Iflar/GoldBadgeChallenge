using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MenuMethodsTest
{
    [TestClass]
    public class CafeTestMethods
    {
        [TestMethod]
        public void Test_AddMenuItem()
        {
            MenuMethodRepo _repo = new MenuMethodRepo();
            Menu menu = new Menu();

            List<Menu> localList = _repo.GetAllMenus();
            int count = localList.Count;

            _repo.AddMenuItemToDir(menu);

            List<Menu> UpdatedLocalList = _repo.GetAllMenus();
            int newCount = UpdatedLocalList.Count;

            bool result = newCount == (count + 1) ? true : false;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_RemoveMenuItem()
        {
            MenuMethodRepo _repo = new MenuMethodRepo();
            Menu menu = new Menu();
            _repo.AddMenuItemToDir(menu);


            List<Menu> localList = _repo.GetAllMenus();
            int count = localList.Count;

            _repo.RemoveMenuItemFromDir(menu);

            List<Menu> UpdatedLocalList = _repo.GetAllMenus();
            int newCount = UpdatedLocalList.Count;

            bool result = newCount == (count - 1) ? true : false;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_UpdateMenuItem()
        {
            MenuMethodRepo _repo = new MenuMethodRepo();
            Menu oldMenu = new Menu(8,"name", "string", 1);

            _repo.AddMenuItemToDir(oldMenu);
            _repo.AddItemToOrder(oldMenu.OrderNum);

            Menu newMenu = new Menu();
            Menu updatedItem = _repo.UpdateMenuItem(oldMenu.OrderNum, newMenu);

            Assert.AreEqual(0, updatedItem.OrderNum); 
        }
        [TestMethod]
        public void Test_ReadMenuList()
        {
            MenuMethodRepo _repo = new MenuMethodRepo();
            List<Menu> listTest = _repo.GetAllMenus();
            bool result = false;
            if (listTest != null)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }
    }
}
