using GoldBadge_FinalProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cafe_UnitTest
{
    [TestClass]
    public class CafeTests
    {
        [TestMethod]
        public void AddMenuItem_ShouldReturnTrue()
        {
            MenuRepository _repo = new MenuRepository();
            Menu burger = new Menu(1, "Big Mac", "The Big Mac Sandwich", "3 buns on a burger", 4.25d);
            Assert.IsTrue(_repo.AddMenuItem(burger));
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            MenuRepository _repo = new MenuRepository();
            Menu burger = new Menu(1, "Big Mac", "The Big Mac Sandwich", "3 buns on a burger", 4.25d);
            _repo.AddMenuItem(burger);
            Assert.IsTrue(_repo.DeleteItem(burger));

        }
        [TestMethod]
        public void GetMenu_ShouldReturnTrue()
        {
            MenuRepository _repo = new MenuRepository();
            Menu burger = new Menu(1, "Big Mac", "The Big Mac Sandwich", "3 buns on a burger", 4.25d);
            _repo.AddMenuItem(burger);
            List<Menu> menu = _repo.GetMenu();
            Assert.IsTrue(menu.Contains(burger));

        }
    }
}
