using System.Collections.Generic;
using DeviceRepairManager.Models;

namespace DeviceRepairManager.Data
{
    internal interface ICustomerRepository
    {
        void Add(Customer customer);
        List<Customer> GetAll();
        void Update(Customer customer);
        void Delete(int customerId);
    }
}
