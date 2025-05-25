using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRepairManager.Models
{
    public class WorkOrder
    {
        public int WorkOrderId { get; set; }
        public int RepairId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string? Status { get; set; }

        public string? Priority { get; set; }
        public string? Notes { get; set; }
        public double HoursWorked { get; set; }
        public bool RequiresApproval { get; set; }      
        public string? CreatedBy { get; set; }           

    }
}
