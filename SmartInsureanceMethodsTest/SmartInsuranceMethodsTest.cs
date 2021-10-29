using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartInsurance_MethodReposotory;
using SmartInsureanceMethodReposotory;
using System;
using System.Collections.Generic;

namespace SmartInsurance_MethodsTest
{
    [TestClass]
    public class SmartInsuranceMthodsTest
    {
        [TestMethod]
        public void Test_AddDriver()
        {
            DriverMethodRepo _repo = new DriverMethodRepo();

            Driver driver = new Driver();

            List<Driver> localList = _repo.GetDrivers();
            int count = localList.Count;

            _repo.AddDriverToDir(driver);

            List<Driver> UpdatedLocalList = _repo.GetDrivers();
            int newCount = UpdatedLocalList.Count;

            bool result = newCount == (count + 1) ? true : false;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_RemoveDriver()
        {
            DriverMethodRepo _repo = new DriverMethodRepo();
            Driver driver = new Driver();
            _repo.AddDriverToDir(driver);
            List<Driver> localList = _repo.GetDrivers();

            int count = localList.Count;

            _repo.RemoveDriverFromDir(driver);

            List<Driver> UpdatedLocalList = _repo.GetDrivers();
            int newCount = UpdatedLocalList.Count;

            bool result = newCount == (count - 1) ? true : false;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_UpdateDriver()
        {
            DriverMethodRepo _repo = new DriverMethodRepo();
            Driver oldDriver = new Driver();
            List<Driver> localList = _repo.GetDrivers();
            int count = localList.Count;
            _repo.AddDriverToDir(oldDriver);

            Driver newDriver = new Driver();

            bool result = _repo.UpdateCustomerInfo(oldDriver.DriverID, newDriver);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_ReadDriverList()
        {
            DriverMethodRepo _repo = new DriverMethodRepo();
            List<Driver> listTest = _repo.GetDrivers();
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
