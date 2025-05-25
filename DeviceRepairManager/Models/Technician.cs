using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRepairManager.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }
        public string? Name { get; set; }
        public string? Expertise { get; set; }

        public bool IsAvailable { get; set; }

        public double TotalWorkHours { get;  set; } = 0;

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsOnLeave { get; set; }
        public int CompletedRepairs { get; set; }
        public string Shift { get; set; }
        public string? PasswordHash { get; set; }
    }
}
