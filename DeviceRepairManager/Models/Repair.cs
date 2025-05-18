using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRepairManager.Models
{
    internal class Repair
    {
            public int RepairId { get; set; }
            public int DeviceId { get; set; }
            public int TechnicianId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Status { get; set; }
            public string Description { get; set; }

            public decimal EstimatedCost { get; set; }
            public decimal FinalCost { get; set; }
            public string? RepairType { get; set; }
            public string? PartsUsed { get; set; }
            public bool NeedsFollowUp { get; set; }

            public void StartRepair() => StartDate = DateTime.Now;
            public void CompleteRepair() => EndDate = DateTime.Now;
            public int GetDurationInDays() => EndDate.HasValue ? (EndDate.Value - StartDate).Days : 0;
            public void UpdateStatus(string newStatus) => Status = newStatus;
            public bool IsCompleted() => Status.ToLower() == "kész";

    }
}
