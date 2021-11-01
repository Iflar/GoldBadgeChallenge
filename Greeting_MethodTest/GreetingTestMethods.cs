using Greeting_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace Greeting_MethodTest
{
    [TestClass]
    public class GreetingTestMethods
    {
        [TestMethod]
        public void Test_AddCustomer()
        {
            CustomerMethodRepo _repo = new CustomerMethodRepo();
            Customer customer = new Customer();

            List<Customer> localList = _repo.GetAllCustomers();
            int count = localList.Count;

            _repo.AddCustomerToDir(customer);

            List<Customer> UpdatedLocalList = _repo.GetAllCustomers();
            int newCount = UpdatedLocalList.Count;

            bool result = newCount == (count + 1) ? true : false;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_RemoveCustomer()
        {
            CustomerMethodRepo _repo = new CustomerMethodRepo();
            Customer customer = new Customer();
            _repo.AddCustomerToDir(customer);
            List<Customer> localList = _repo.GetAllCustomers();

            int count = localList.Count;

            _repo.RemoveCustomerFromDir(customer);

            List<Customer> UpdatedLocalList = _repo.GetAllCustomers();
            int newCount = UpdatedLocalList.Count;

            bool result = newCount == (count - 1) ? true : false;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_UpdateCustomer()
        {
            CustomerMethodRepo _repo = new CustomerMethodRepo();
            Customer oldCustomer = new Customer();
            List<Customer> localList = _repo.GetAllCustomers();
            int count = localList.Count;
            _repo.AddCustomerToDir(oldCustomer);

            Customer newCustomer = new Customer();

            bool result = _repo.UpdateCustomerInfo(oldCustomer.CustomerID, newCustomer);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_ReadCustomerList()
        {
            CustomerMethodRepo _repo = new CustomerMethodRepo();
            List<Customer> listTest = _repo.GetAllCustomers();
            bool result = false;
            if (listTest != null)
            {
                result = true;
            }
            Assert.IsTrue(result);
            Assert.AreEqual(0, listTest.Count);
        }
    }
}
