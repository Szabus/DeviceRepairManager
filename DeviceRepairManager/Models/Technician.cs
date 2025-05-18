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

            public int ExperienceYears { get; set; }
            public string? Certification { get; set; }
            public bool IsAvailable { get; set; }
            public string? Shift { get; set; }
            public int OngoingRepairs { get; set; }
            public string? Notes { get; set; }

            public void AssignRepair() => OngoingRepairs++;
            public void CompleteRepair() => OngoingRepairs--;
            public bool CanTakeMoreWork() => OngoingRepairs < 5;
            public void SetAvailability(bool available) => IsAvailable = available;
            public void AddNote(string note) => Notes += "\n" + note;

    }
}
