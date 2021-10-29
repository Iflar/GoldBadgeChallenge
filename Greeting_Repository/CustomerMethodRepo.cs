using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public class CustomerMethodRepo
    {
        protected readonly List<Customer> _customerDirectory = new List<Customer>();

        public bool AddCustomerToDir(Customer customer)
        {
            int start = _customerDirectory.Count;
            _customerDirectory.Add(customer);
            return _customerDirectory.Count > start ? true : false;
        }
        public bool RemoveCustomerFromDir(Customer customer)
        {
            int start = _customerDirectory.Count;
            _customerDirectory.Remove(customer);
            return _customerDirectory.Count < start ? true : false;
        }
        public bool UpdateCustomerInfo(int customerID, Customer updatedCustomer)
        {
            Customer oldCustomer = GetCustomerByID(customerID);
            if (oldCustomer != null)
            {
                oldCustomer.FirstName = updatedCustomer.FirstName;
                oldCustomer.LastName = updatedCustomer.LastName;
                oldCustomer.DateActive = updatedCustomer.DateActive;
                return true;
            }
            return false;
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerDirectory;
        }
        public Customer GetCustomerByID(int customerID)
        {
            foreach(Customer customer in _customerDirectory)
            {
                if (customer.CustomerID == customerID)
                {
                    return customer;
                }
            }
            return null;
        }
        public List<Customer> GetSortedList(List<Customer> customerList)
        {
            List<Customer> sortedList = customerList.OrderBy(cn => cn.FirstName).ThenBy(cn => cn.LastName).ToList();
            return sortedList;
        }
    }
}
