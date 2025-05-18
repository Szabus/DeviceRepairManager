using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRepairManager.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? ContactInfo { get; set; }
        public string? Address { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsVIP { get; set; }
        public string? Notes { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PreferredContactMethod { get; set; }

        public Repair SubmitRepairRequest(int deviceId, string problemDescription)
        {
            return new Repair
            {
                DeviceId = deviceId,
                Notes = problemDescription,
                IsUnderRepair = true,
                CustomerId = this.CustomerId
            };
        }
        public string TrackRepairStatus(List<Repair> allRepairs)
        {
            var myRepairs = allRepairs.Where(r => r.CustomerId == this.CustomerId && r.IsUnderRepair).ToList();
            if (myRepairs.Count == 0) return "Nincs folyamatban lévő javítás.";
            return string.Join("\n", myRepairs.Select(r => $"Eszköz #{r.DeviceId} - Állapot: javítás alatt"));
        }

        public void UpdateContactInfo(string newContact) => ContactInfo = newContact;
        public bool IsRegisteredLongerThan(int days) => (DateTime.Now - RegistrationDate).TotalDays > days;
        public void MarkAsVIP() => IsVIP = true;
        public void AddNote(string note) => Notes += "\n" + note;
        public string GetFullAddress() => $"{Address}, {PostalCode} {City}";
    }
}
