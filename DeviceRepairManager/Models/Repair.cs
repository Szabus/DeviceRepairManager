using System;

namespace DeviceRepairManager.Models
{
    public class Repair
    {
        public int RepairId { get; set; }
        public int DeviceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public bool CustomerApproved { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Notes { get; set; }
        public int RepairCount { get; set; }
        public bool IsUnderRepair { get; set; }

        private decimal _loggedHours = 0;

        public void UpdateRepairStatus(string newStatus)
        {
            Status = newStatus;
            if (newStatus?.ToLower() == "kész")
            {
                EndDate = DateTime.Now;
                IsUnderRepair = false;
                RepairCount++;
            }
        }

      
        public void LogWorkHours(decimal hours)
        {
            _loggedHours += hours;
        }
    }
}
