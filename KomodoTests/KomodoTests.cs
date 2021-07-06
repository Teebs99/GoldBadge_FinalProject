using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KomodoInsurance;
using System.Collections.Generic;

namespace KomodoTests
{
    [TestClass]
    public class KomodoTests
    {
        BadgeRepo _repo;
        Badge badge;
        [TestInitialize]
        public void TestInitialize()
        {
            _repo = new BadgeRepo();
            badge = new Badge(1);
            _repo.AddBadge(badge);
        }
        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            Assert.IsTrue(_repo.GetBadges().ContainsKey(badge.BadgeId));
        }
        [TestMethod]
        public void AddDoor_ShouldReturnTrue()
        {
            string door = "A5";
            _repo.AddDoor(badge.BadgeId, door);
            Assert.IsTrue(_repo.GetBadges()[badge.BadgeId].Contains(door));
        }
        [TestMethod]
        public void GetBadges_ShouldBeEqual()
        {
            Dictionary<int, List<string>> newDict = _repo.GetBadges();
            Assert.IsNotNull(newDict);
        }
        [TestMethod]
        public void UpdateDoor_ShouldReturnTrue()
        {
            string door = "A5";
            _repo.AddDoor(badge.BadgeId, door);
            string newDoor = "B7";
            Assert.IsTrue(_repo.UpdateDoor(1, "A5", newDoor));
        }
        [TestMethod]
        public void DeleteDoor()
        {
            string door = "A5";
            _repo.AddDoor(badge.BadgeId, door);
            Assert.IsTrue(_repo.DeleteDoor(badge.BadgeId, door));

        }
        [TestMethod]
        public void DeleteAllDoors()
        {
            Badge newBadge = new Badge(2);
            _repo.AddBadge(newBadge);
            _repo.AddDoor(2, "A5");
            _repo.AddDoor(2, "B6");
            _repo.AddDoor(2, "C2");
            Assert.IsTrue(_repo.DeleteAllDoors(2));
        }
    }
}
