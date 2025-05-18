internal class Repair
{
    public int RepairId { get; set; }                // egyedi javítás azonosító
    public int DeviceId { get; set; }                // eszköz azonosító
    public string? Type { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNumber { get; set; }
    public int CustomerId { get; set; }              // ügyfél azonosító
    public DateTime PurchaseDate { get; set; }
    public string? WarrantyStatus { get; set; }
    public string? Color { get; set; }
    public string? PowerSupply { get; set; }
    public string? Location { get; set; }
    public string? Condition { get; set; }
    public string? Notes { get; set; }
    public string? Category { get; set; }
    public bool IsUnderRepair { get; set; }
    public int RepairCount { get; set; }

    public DateTime StartDate { get; set; }          
    public DateTime? EndDate { get; set; }            
    public string? Status { get; set; }                
    public string? Description { get; set; }           
    public bool CustomerApproved { get; set; }         
    public int? TechnicianId { get; set; }              

    public void AssignToCustomer(int customerId)
    {
        CustomerId = customerId;
    }

    public void UpdateWarranty(string status)
    {
        WarrantyStatus = status;
    }

    public void MarkAsRepaired()
    {
        IsUnderRepair = false;
        RepairCount++;
        EndDate = DateTime.Now;
        Status = "Kész";
    }

    public bool NeedsRepair()
    {
        return Condition == "Hibás";
    }

    public string GetDeviceSummary()
    {
        return $"{Brand} {Model} - SN: {SerialNumber}";
    }
}
