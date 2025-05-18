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

          
            public void UpdateContactInfo(string newContact) => ContactInfo = newContact;
            public bool IsRegisteredLongerThan(int days) => (DateTime.Now - RegistrationDate).TotalDays > days;
            public void MarkAsVIP() => IsVIP = true;
            public void AddNote(string note) => Notes += "\n" + note;
            public string GetFullAddress() => $"{Address}, {PostalCode} {City}";
    }
}
