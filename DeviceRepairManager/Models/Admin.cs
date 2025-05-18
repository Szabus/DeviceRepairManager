using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRepairManager.Models
{
    internal class Admin
    {
        public int AdminId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public void AddCustomer(List<Customer> customers, Customer newCustomer)
        {
            customers.Add(newCustomer);
        }

        public void AddTechnician(List<Technician> technicians, Technician newTech)
        {
            technicians.Add(newTech);
        }
        public void UpdateWorkOrderStatus(List<WorkOrder> workOrders, int workOrderId, string newStatus)
        {
            var workOrder = workOrders.FirstOrDefault(w => w.WorkOrderId == workOrderId);
            if (workOrder != null)
            {
                workOrder.Status = newStatus;
                if (newStatus == "Kész")
                {
                    workOrder.CompletionDate = DateTime.Now;
                }
            }
        }

    }
}
