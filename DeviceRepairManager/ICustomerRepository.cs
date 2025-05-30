using System.Collections.Generic;
using DeviceRepairManager.Models;

namespace DeviceRepairManager.Data
{
    internal interface ICustomerRepository
    {
        public void CreateRepairRequest(int customerId, int deviceId, string description);

        public List<Repair> GetRepairsByCustomer(int customerId);

        public string? GetCustomerNameById(int customerId);
    }
}
