using System;
using System.Collections.Generic;
using System.Linq;

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
            if (newCustomer != null)
                customers.Add(newCustomer);
        }

        public void RemoveCustomer(List<Customer> customers, int customerId)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer != null)
                customers.Remove(customer);
        }

        public void UpdateCustomerName(List<Customer> customers, int customerId, string newName)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer != null)
                customer.Name = newName;
        }

        public void AddTechnician(List<Technician> technicians, Technician newTech)
        {
            if (newTech != null)
                technicians.Add(newTech);
        }

        public void RemoveTechnician(List<Technician> technicians, int technicianId)
        {
            var tech = technicians.FirstOrDefault(t => t.TechnicianId == technicianId);
            if (tech != null)
                technicians.Remove(tech);
        }

        public void UpdateTechnicianAvailability(List<Technician> technicians, int technicianId, bool isAvailable)
        {
            var tech = technicians.FirstOrDefault(t => t.TechnicianId == technicianId);
            if (tech != null)
                tech.IsAvailable = isAvailable;
        }

        public void UpdateWorkOrderStatus(List<WorkOrder> workOrders, int workOrderId, string newStatus)
        {
            var workOrder = workOrders.FirstOrDefault(w => w.WorkOrderId == workOrderId);
            if (workOrder != null)
                workOrder.Status = newStatus;
        }
    }
}
