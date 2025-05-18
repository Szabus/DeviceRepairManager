using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRepairManager.Models
{
    internal class WorkOrder
    {
        public int WorkOrderId { get; set; }
        public int RepairId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string? Status { get; set; }

        public string? CreatedBy { get; set; }
        public string? Priority { get; set; }
        public string? Notes { get; set; }
        public bool IsPrinted { get; set; }
        public bool RequiresApproval { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime ApprovalDate { get; set; }
        public int TechnicianId { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public decimal TotalCost { get; set; }
        public string? PartsUsed { get; set; }
        public double HoursWorked { get; set; }

        public void CloseWorkOrder() => CompletionDate = DateTime.Now;
        public void AddNote(string note) => Notes = (Notes ?? "") + "\n" + note;
        public bool IsOverdue() => DateTime.Now > CreationDate.AddDays(7) && CompletionDate == null;
        public void MarkAsPrinted() => IsPrinted = true;
        public void ChangePriority(string newPriority) => Priority = newPriority;
    }
}
