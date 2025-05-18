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

        public bool IsAvailable { get; set; }

        public decimal TotalWorkHours { get; private set; } = 0;

        public void LogWorkHours(decimal hours)
        {
            TotalWorkHours += hours;
        }
    }
}
