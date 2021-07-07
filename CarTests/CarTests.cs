using Cars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CarTests
{
    [TestClass]
    public class CarTests
    {
        CarRepo _repo;
        Car car;
        Car gas;
        Car hybrid;
        [TestInitialize]
        public void SeedData()
        {
            _repo = new CarRepo();
            car = new Car("Tesla", "Roadster", CarType.Electric);
            gas = new Car("Pontiac", "G6", CarType.Gas);
            hybrid = new Car("Prius", "Model 1", CarType.Hybrid);
        }
        [TestMethod]
        public void AddCar_ShouldReturnTrue()
        {
            _repo.AddCar(car);
        }
        [TestMethod]
        public void GetCars_ShouldReturnListOfCars()
        {
            _repo.AddCar(car);
            List<Car> cars = new List<Car>();
            cars = _repo.GetAllCars();
            Assert.IsTrue(cars.Contains(car));
        }
        [TestMethod]
        public void GetElectric_ShouldReturnListOfElectrics()
        {
            _repo.AddCar(car);
            List<Car> cars = new List<Car>();
            cars = _repo.GetElectric();
            Assert.IsTrue(cars.Contains(car));

        }
        [TestMethod]
        public void GetAllGas_ShouldReturnListOfGas()
        {
            _repo.AddCar(gas);
            List<Car> cars = new List<Car>();
            cars = _repo.GetGas();
            Assert.IsTrue(cars.Contains(gas));
        }
        [TestMethod]
        public void GetAllHybrid_ShouldReturnListOfHybrid()
        {
            _repo.AddCar(hybrid);
            List<Car> cars = new List<Car>();
            cars = _repo.GetHybrid();
            Assert.IsTrue(cars.Contains(hybrid));
        }
        [TestMethod]
        public void UpdateCar_ShouldReturnTrue()
        {
            _repo.AddCar(car);
            Car newCar = new Car("Tesla", "Model S", CarType.Electric);
            _repo.UpdateCar(car, newCar);
            Assert.AreEqual(newCar.Model, _repo.GetAllCars()[0].Model);
        }
        [TestMethod]
        public void DeleteCar_ShouldReturnTrue()
        {
            _repo.AddCar(car);
            Assert.IsTrue(_repo.DeleteCar(car));
        }
    }
}
