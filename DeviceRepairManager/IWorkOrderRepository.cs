using DeviceRepairManager.Models;
using System.Collections.Generic;

namespace DeviceRepairManager.Repositories
{
    public interface IWorkOrderRepository
    {
        List<WorkOrder> GetAllWorkOrders();
        WorkOrder? GetWorkOrderById(int id);
        void AddWorkOrder(WorkOrder workOrder);
        void UpdateWorkOrder(WorkOrder workOrder);
        void DeleteWorkOrder(int id);
    }
}
