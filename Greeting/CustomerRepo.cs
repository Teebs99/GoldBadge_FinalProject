using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    public class CustomerRepo
    {
        protected readonly List<Customer> _customers = new List<Customer>();

        public bool AddCustomer(Customer customer)
        {
            int count = _customers.Count;
            _customers.Add(customer);
            return count < _customers.Count;
        }
        public List<Customer> GetCustomers()
        {
            _customers.Sort((c1, c2) => c1.LastName.CompareTo(c2.LastName));
            return _customers;
        }
        public Customer GetCustomer(Customer customer)
        {
            foreach(Customer person in _customers)
            {
                if(person.FirstName == customer.FirstName & person.LastName == customer.LastName)
                {
                    return customer;
                }
            }
            return null;
        }
        public Customer GetCustomerByName(string firstname, string lastname)
        {
            foreach (Customer person in _customers)
            {
                if (person.FirstName == firstname & person.LastName == lastname)
                {
                    return person;
                }
            }
            return null;
        }
        public bool UpdateCustomer(Customer customer, Customer updated)
        {
            Customer originalCustomer = GetCustomer(customer);
            if (originalCustomer != null)
            {
                originalCustomer.FirstName = updated.FirstName;
                originalCustomer.LastName = updated.LastName;
                originalCustomer.CustomerType = updated.CustomerType;
                originalCustomer.Message();
                return true;
            }
            return false;
        }
        public bool DeleteCustomer(Customer customer)
        {
            return _customers.Remove(GetCustomer(customer));
        }
    }
}
