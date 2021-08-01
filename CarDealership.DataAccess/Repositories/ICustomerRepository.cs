using System.Collections.Generic;
using CarDealership.DataAccess.Models;

namespace CarDealership.DataAccess.Repositories
{
    public interface ICustomerRepository
    {
        IList<Customer> GetCustomers(string name);
        void Delete(int id);

        void Add(Customer customer);
        void Update(Customer customer);
    }
}
