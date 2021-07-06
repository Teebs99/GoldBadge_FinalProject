using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_FinalProject
{
    public class Menu
    {
        public int MealNumber { get; }
        public string MealName { get; }
        public string Description { get; }
        public string Ingredients { get; }
        public double Price { get; }

        public Menu(int mealNumber, string name, string desc, string ingredients, double price)
        {
            MealNumber = mealNumber;
            MealName = name;
            Description = desc;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
