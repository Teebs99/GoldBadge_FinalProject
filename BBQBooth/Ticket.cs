using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBQBooth
{
    public enum TicketType { Burger, Treat };
    public class Ticket
    {
        public double MealCost { get; set; }
        public double MiscCost { get; set; }
        public TicketType MealType { get; set; }
        public Ticket(TicketType type, double meal, double misc)
        {
            MealType = type;
            MealCost = meal;
            MiscCost = misc;
        }
    }
}
