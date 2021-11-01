﻿using SmartInsurance_MethodReposotory;
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
        public bool UpdateDriverInfo(int driverID, Driver updatedDriver)
        {
            Driver oldDriver = GetDriverByID(driverID);
            if (oldDriver != null)
            {
                oldDriver.FirstName = updatedDriver.FirstName;
                oldDriver.LastName = updatedDriver.LastName;
                oldDriver.GoodHabits = updatedDriver.GoodHabits;
                oldDriver.BadHabits = updatedDriver.BadHabits;
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
        public Driver GenerateHabits(Driver driver)
        {
            List<GoodHabit> goodHabits = driver.GoodHabits;
            goodHabits.Add(GoodHabit.None);
            List<BadHabit> badHabits = driver.BadHabits;
            badHabits.Add(BadHabit.None);

            Random random = new Random();
            int numGoodHabits = random.Next(0, 4);
            int numBadHabits = random.Next(0, 4);

            List<GoodHabit> gHabitList = new List<GoodHabit>();
            int gCycle = 0;
            while (numGoodHabits > 0)
            {
                var habit = Enum.GetValues(typeof(GoodHabit)).GetValue(gCycle);
                GoodHabit selectedHabit = (GoodHabit)habit;

                foreach (GoodHabit goodHabit in goodHabits)
                {
                    if (selectedHabit != goodHabit)
                    {
                        gHabitList.Add(selectedHabit);
                    }
                }

                foreach(GoodHabit goodHabit in gHabitList)
                {
                    goodHabits.Add(goodHabit);
                }
                ++gCycle;
                --numGoodHabits;
            }

            List<BadHabit> bHabitList = new List<BadHabit>();
            int bCycle = 0;
            while (numBadHabits > 0)
            {
                var habit = Enum.GetValues(typeof(BadHabit)).GetValue(bCycle);
                BadHabit selectedHabit = (BadHabit)habit;

                foreach (BadHabit badHabit in badHabits)
                {
                    if (selectedHabit != badHabit)
                    {
                        bHabitList.Add(selectedHabit);
                    }
                }

                foreach (BadHabit badHabit in bHabitList)
                {
                    badHabits.Add(badHabit);
                }
                ++bCycle;
                --numBadHabits;
            }
            goodHabits.Remove(GoodHabit.None);
            badHabits.Remove(BadHabit.None);
            return driver;
        }
        public double CalculatePremiumByHabit(Driver driver)
        {
            List<GoodHabit> goodHabits = driver.GoodHabits;
            List<BadHabit> badHabits = driver.BadHabits;
            double premium = driver.Premium;

            foreach (GoodHabit goodHabit in goodHabits)
            {
                premium = premium - (premium * 0.2);
            }
            foreach (BadHabit badHabit in badHabits)
            {
                premium = premium + (premium * 0.3);
            }
            return premium;
        }
        public Driver NewGenerateHabits(Driver driver)
        {
            //Actually simulates scenarios to test the driver's skill

            return driver;
        }
    }
}
