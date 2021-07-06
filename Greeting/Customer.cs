using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    public enum GreetingType { Potential, Past, Current };
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GreetingType CustomerType { get; set; }
        public string Email { get; set; }

        public Customer(string firstname, string lastname, GreetingType customertype)
        {
            FirstName = firstname;
            LastName = lastname;
            CustomerType = customertype;
            Email = Message();
        }
        public string Message()
        {
            switch (CustomerType)
            {
                case GreetingType.Potential:
                    return "We currently have the lowest rates on Helicopter Insurance!";
                    
                case GreetingType.Past:
                    return "It's been a long time since we've heard from you, we want you back";
                    
                case GreetingType.Current:
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
            }
            return null;
        }
    }
}
