using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(string customerID);
        Customer Add(Customer item);
        void Remove(string customerID);
        bool Update(Customer item);
    }
}
