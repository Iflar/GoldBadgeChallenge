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
        public Driver GenerateHabbits(Driver driver)
        {
            List<GoodHabbit> goodHabbits = driver.GoodHabbits;
            List<BadHabbit> badHabbits = driver.BadHabbits;

            Random random = new Random();
            int numGoodHabbits = random.Next(0, 4);
            int numBadHabbits = random.Next(0, 4);

            while(numGoodHabbits >= 0)
            {
                int cycle = 0;
                var habbit = Enum.GetValues(typeof(GoodHabbit)).GetValue(cycle);
                GoodHabbit selectedHabbit = (GoodHabbit)habbit;

                foreach (GoodHabbit goodHabbit in goodHabbits)
                {
                    if (selectedHabbit != goodHabbit)
                    {
                        goodHabbits.Add(selectedHabbit);
                    }
                }
                ++cycle;
                --numGoodHabbits;
            }
            while (numBadHabbits >= 0)
            {
                int cycle = 0;
                var habbit = Enum.GetValues(typeof(BadHabbit)).GetValue(cycle);
                BadHabbit selectedHabbit = (BadHabbit)habbit;

                foreach (BadHabbit badHabbit in badHabbits)
                {
                    if (selectedHabbit != badHabbit)
                    {
                        badHabbits.Add(selectedHabbit);
                    }
                }
                ++cycle;
                --numBadHabbits;
            }

            return driver;
        }
        public double CalculatePremiumByHabbit(Driver driver)
        {
            List<GoodHabbit> goodHabbits = driver.GoodHabbits;
            List<BadHabbit> badHabbits = driver.BadHabbits;
            double premium = driver.Premium;

            foreach (GoodHabbit goodHabbit in goodHabbits)
            {
                premium = premium - (premium * 0.2);
            }
            foreach (BadHabbit badHabbit in badHabbits)
            {
                premium = premium + (premium * 0.3);
            }
            return premium;
        }
    }
}
