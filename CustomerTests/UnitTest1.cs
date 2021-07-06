using Greeting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CustomerTests
{
    [TestClass]
    public class UnitTest1
    {
        CustomerRepo _repo;
        Customer customer;
        [TestInitialize]
        public void SeedData()
        {
            _repo = new CustomerRepo();
            customer = new Customer("Stephen", "Ives", GreetingType.Current);
        }
        [TestMethod]
        public void AddCustomer_ShouldReturnTrue()
        {
            Assert.IsTrue(_repo.AddCustomer(customer));
        }
        [TestMethod]
        public void GetCustomers_ShouldReturnList()
        {
            _repo.AddCustomer(customer);
            List<Customer> list = new List<Customer>();
            list = _repo.GetCustomers();
            Assert.IsTrue(list.Contains(customer));
        }
        [TestMethod]
        public void GetCustomer_ShouldReturnCustomer()
        {
            _repo.AddCustomer(customer);
            Assert.AreEqual(customer, _repo.GetCustomer(customer));
        }
        [TestMethod]
        public void GetCustomerByName_ShouldBeEqual()
        {
            _repo.AddCustomer(customer);
            Assert.AreEqual("Stephen", _repo.GetCustomerByName("Stephen", "Ives").FirstName);
        }
        [TestMethod]
        public void UpdateCustomer_ShouldReturnTrue()
        {
            Customer updatedCustomer = new Customer("Steve", "Ives", GreetingType.Current);
            _repo.AddCustomer(customer);
            _repo.UpdateCustomer(customer, updatedCustomer);
            Assert.AreEqual(updatedCustomer.FirstName, _repo.GetCustomers()[0].FirstName);
        }
        [TestMethod]
        public void DeleteCustomer_ShouldReturnTrue()
        {
            _repo.AddCustomer(customer);
            Assert.IsTrue(_repo.DeleteCustomer(customer));

        }
    }
}
