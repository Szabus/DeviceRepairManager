using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRepairManager.Models
{
    internal class Device
    {
            public int DeviceId { get; set; }
            public string? Type { get; set; }
            public string? Brand { get; set; }
            public string? Model { get; set; }
            public string? SerialNumber { get; set; }
            public int CustomerId { get; set; }

            public DateTime PurchaseDate { get; set; }
            public bool UnderWarranty { get; set; }
            public string? Color { get; set; }
            public string? LocationInShop { get; set; }
            public string? Comment { get; set; }

       
            public bool IsWarrantyValid() => UnderWarranty && (DateTime.Now - PurchaseDate).TotalDays < 730;
            public string GetDeviceLabel() => $"{Brand} {Model} - {SerialNumber}";
            public void UpdateLocation(string newLocation) => LocationInShop = newLocation;
            public void AddComment(string comment) => Comment += "\n" + comment;
            public int GetDeviceAgeInDays() => (DateTime.Now - PurchaseDate).Days;
    }
}
