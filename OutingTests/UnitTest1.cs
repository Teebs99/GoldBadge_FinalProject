using CompanyOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace OutingTests
{
    [TestClass]
    public class UnitTest1
    {
        OutingRepo _repo;
        Outing outing;
        [TestInitialize]
        public void SeedData()
        {
            _repo = new OutingRepo();
            outing = new Outing(EventType.Golf,6,DateTime.Now,150d);

        }
        [TestMethod]
        public void AddOuting_ShouldReturnTrue()
        {
            Assert.IsTrue(_repo.AddOuting(outing));
        }
        [TestMethod]
        public void GetOutings_ShouldReturnList()
        {
            List<Outing> expected = new List<Outing>();
            expected.Add(outing);
            _repo.AddOuting(outing);
            Assert.AreEqual(expected[0], _repo.GetOutings()[0]);
        }
        [TestMethod]
        public void UpdatedOuting_ShouldReturnTrue()
        {
            _repo.AddOuting(outing);
            Outing newOuting = new Outing(EventType.Concert, 6, DateTime.Now, 300d);
            Assert.IsTrue(_repo.UpdateOuting(outing, newOuting));
        }
        public void DeleteOuting_ShouldReturnTrue()
        {
            _repo.AddOuting(outing);
            Assert.IsTrue(_repo.DeleteOuting(outing));
        }
    }
}
