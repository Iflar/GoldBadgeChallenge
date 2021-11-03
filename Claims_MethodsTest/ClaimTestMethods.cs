using Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Claims_MethodsTest
{
    [TestClass]
    public class ClaimTestMethods
    {
        
        private ClaimMethodRepo _repo;
        private Claim _claim;
        private List<Claim> _directory;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimMethodRepo();
            _claim = new Claim(1, TypeClaim.Car, "A car was completely destroyed!", 12000, new DateTime(2021,11,03), new DateTime(2021,11,01));
            _directory = _repo.GetClaims();
        }

        [TestMethod]
        public void Test_AddClaimToDir()
        {
            int count = _directory.Count;
            _repo.AddClaimToDir(_claim);
            int newCount = _directory.Count;
            bool result = newCount == (count + 1) ? true : false;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_RemoveClaimFromDir()
        {
            _repo.AddClaimToDir(_claim);
            int count = _directory.Count;
            _repo.RemoveClaimFromDir(_claim);
            int newCount = _directory.Count;
            bool result = newCount == (count - 1) ? true : false;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_ReadClaims()
        {
            _repo.AddClaimToDir(_claim);
            List<Claim> listTest = _repo.GetClaims();

            bool result = false;
            if (listTest.Count == 1)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_UpdateClaim()
        {
            _repo.AddClaimToDir(_claim);
            Claim newClaim = new Claim(2, TypeClaim.Theft, "The whole house was stolen!", 103190301, new DateTime(2019,10,15), new DateTime(2019,09,29));

            _repo.UpdateClaim(_claim.ClaimID, newClaim);

            Assert.AreEqual(newClaim.ClaimType, _claim.ClaimType);
        }
    }
}
