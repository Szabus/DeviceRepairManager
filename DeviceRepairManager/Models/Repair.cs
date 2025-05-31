using System;

namespace DeviceRepairManager.Models
{
    public class Repair
    {
        public int RepairId { get; set; }
        public int DeviceId { get; set; }
        public int CustomerId { get; set; }
        public int TechnicianId { get; set; } 
        public DateTime StartDate { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public bool CustomerApproved { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Notes { get; set; }
        public int RepairCount { get; set; }
        public bool IsUnderRepair { get; set; }
        public int WorkOrderId { get; set; }

    }
}
