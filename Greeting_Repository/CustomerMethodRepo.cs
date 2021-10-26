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

        public bool AddCustomertoDir()
        {

            return false;
        }
        public bool RemoveCustomerFromDir()
        {

            return false;
        }
        public bool UpdateCustomerInfo()
        {
            return false;
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerDirectory;
        }

    }
}
