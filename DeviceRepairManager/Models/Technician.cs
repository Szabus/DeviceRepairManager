using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRepairManager.Models
{
    internal class Technician
    {
        public int TechnicianId { get; set; }
        public string? Name { get; set; }
        public string? Expertise { get; set; }
        public string? ContactInfo { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string? Address { get; set; }
        public bool IsAvailable { get; set; }
        public int Workload { get; set; }
        public string? Certifications { get; set; }
        public string? AssignedShift { get; set; }
        public bool OnLeave { get; set; }
        public string? Notes { get; set; }

        public void AssignRepair(int repairId)
        {
            Workload++;
            Console.WriteLine($"Repair {repairId} assigned to {Name}");
        }

        public void UpdateAvailability(bool available)
        {
            IsAvailable = available;
        }

        public void LogWorkHours(decimal hours)
        {
            Console.WriteLine($"{Name} rögzített {hours} munkaórát.");
        }

        public string GetTechnicianInfo()
        {
            return $"{Name} ({Expertise}) - {Email}";
        }

        public void AddCertification(string cert)
        {
            Certifications += cert + ", ";
        }

        public void UpdateRepairStatus(Repair repair, string newStatus)
        {
            repair.Status = newStatus;
            if (newStatus == "Kész")
            {
                repair.EndDate = DateTime.Now;
            }
        }
    }
}
