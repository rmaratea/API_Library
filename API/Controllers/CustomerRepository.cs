using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Controllers
{
    class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetAll()
        {
            var result = new List<Customer>();
            result.Add(
                new Customer()
                {
                    City = "Varese",
                    ContactName = "Shatan",
                    CustomerID = Guid.NewGuid().ToString()
                });

            return result;
        }

        public Customer Get(string customerID)
        {
            throw new NotImplementedException();
        }

        public Customer Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public void Remove(string customerID)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
