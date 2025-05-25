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
        public string? PasswordHash { get; set; }
   
    }
}
