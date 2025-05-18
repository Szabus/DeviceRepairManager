internal class Device
{
    public int DeviceId { get; set; }
    public string? Type { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? SerialNumber { get; set; }
    public int CustomerId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string? WarrantyStatus { get; set; }
    public string? Condition { get; set; }

    public string? Location { get; set; }
    public string? Color { get; set; }

    public string GetDeviceSummary()
    {
        return $"{Brand} {Model} - SN: {SerialNumber}";
    }

    public bool NeedsRepair()
    {
        return Condition == "Hibás";
    }
}
