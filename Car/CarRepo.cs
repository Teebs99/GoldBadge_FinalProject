using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class CarRepo
    {
        protected readonly List<Car> _cars = new List<Car>();
        protected readonly List<Car> _electric = new List<Car>();
        protected readonly List<Car> _gas = new List<Car>();
        protected readonly List<Car> _hybrid = new List<Car>();

        public bool AddCar(Car car)
        {
            int count = _cars.Count;
            _cars.Add(car);
            switch (car.CarType)
            {
                case CarType.Electric:
                    _electric.Add(car);
                    break;
                case CarType.Hybrid:
                    _hybrid.Add(car);
                    break;
                case CarType.Gas:
                    _gas.Add(car);
                    break;
            }
            return count < _cars.Count;
        }
        public List<Car> GetAllCars()
        {
            return _cars;
        }
        public List<Car> GetElectric()
        {
            return _electric;
        }
        public List<Car> GetHybrid()
        {
            return _hybrid;
        }
        public List<Car> GetGas()
        {
            return _gas;
        }
        public Car GetCar(string make, string model)
        {
            foreach(Car car in _cars)
            {
                if(car.Make == make & car.Model == model)
                {
                    return car;
                }
            }
            return null;
        }
        public bool UpdateCar(Car oldCar, Car updated)
        {
            foreach(Car car in _cars)
            {
                if(car.Make == oldCar.Make & car.Model == oldCar.Model)
                {
                    oldCar.Make = updated.Make;
                    oldCar.Model = updated.Model;
                    oldCar.CarType = updated.CarType;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteCar(Car car)
        {
            if (_electric.Contains(car)) _electric.Remove(car);
            if (_hybrid.Contains(car)) _hybrid.Remove(car);
            if (_gas.Contains(car)) _gas.Remove(car);
            return _cars.Remove(car);
        }
    }
}
