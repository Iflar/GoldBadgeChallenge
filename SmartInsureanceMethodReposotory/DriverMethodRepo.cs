using SmartInsurance_MethodReposotory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInsureanceMethodReposotory
{
    public class DriverMethodRepo
    {
        protected readonly List<Driver> _driverDirectory = new List<Driver>();
        public bool AddDriverToDir(Driver driver)
        {
            int start = _driverDirectory.Count;
            _driverDirectory.Add(driver);
            return _driverDirectory.Count > start ? true : false;
        }
        public bool RemoveDriverFromDir(Driver driver)
        {
            int start = _driverDirectory.Count;
            _driverDirectory.Remove(driver);
            return _driverDirectory.Count < start ? true : false;
        }
        public bool UpdateCustomerInfo(int driverID, Driver updatedDriver)
        {
            Driver oldDriver = GetDriverByID(driverID);
            if (oldDriver != null)
            {
                oldDriver.FirstName = updatedDriver.FirstName;
                oldDriver.LastName = updatedDriver.LastName;
                oldDriver.GoodHabbits = updatedDriver.GoodHabbits;
                oldDriver.BadHabbits = updatedDriver.BadHabbits;
                oldDriver.Premium = updatedDriver.Premium;
                return true;
            }
            return false;
        }
        public List<Driver> GetDrivers()
        {
            return _driverDirectory;
        }
        public Driver GetDriverByID(int driverID)
        {
            foreach (Driver Driver in _driverDirectory)
            {
                if (Driver.DriverID == driverID)
                {
                    return Driver;
                }
            }
            return null;
        }
    }
}
