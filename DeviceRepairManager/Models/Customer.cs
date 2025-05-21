using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceRepairManager.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? ContactInfo { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsVIP { get; set; }

        public Repair SubmitRepairRequest(int deviceId, string problemDescription)
        {
            return new Repair
            {
                DeviceId = deviceId,
                CustomerId = this.CustomerId,
                StartDate = DateTime.Now,
                Status = "Leadva",
                Description = problemDescription,
                CustomerApproved = true
            };
        }

        public List<string> TrackRepairStatus(List<Repair> allRepairs)
        {
            var myRepairs = allRepairs
                .Where(r => r.CustomerId == this.CustomerId && r.CustomerApproved && r.Status != "Kész")
                .Select(r => $"Eszköz #{r.DeviceId} - Állapot: {r.Status}")
                .ToList();

            return myRepairs;
        }

        public void UpdateContactInfo(string newContact)
        {
            ContactInfo = newContact;
        }
    }
}
