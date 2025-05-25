using DeviceRepairManager.Models;

namespace DeviceRepairManager.Repositories
{
    public interface IAdminRepository
    {
        public List<Customer> GetAllCustomers();

        public void AddCustomer(Customer customer);

        public List<Technician> GetAllTechnicians();

        public List<WorkOrder> GetAllWorkOrders();
    }
}
