using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public enum EventType { Golf, Bowling, Amusement_Park, Concert }
    public class Outing
    {
        public EventType Type { get; set; }
        public int NumPeople { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get;}
        public double Cost { get; set; }
        public Outing(EventType type, int people, DateTime date, double cost)
        {
            Type = type;
            NumPeople = people;
            Date = date;
            Cost = cost;
            CostPerPerson =(decimal)cost / people;

        }
    }
}
