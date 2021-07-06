using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{   public enum CarType { Electric, Hybrid, Gas };
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public CarType CarType { get; set; }

        public Car(string make, string model, CarType type)
        {
            Make = make;
            Model = model;
            CarType = type;
        }
    }
}
