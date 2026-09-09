namespace RubberTradingSystem.Models;

public class TruckModel // (သို့ TruckStockModel)
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string? staff_id { get; set; }
    public string truck_number { get; set; } = string.Empty;
    public string driver_name { get; set; } = string.Empty;
    public string status { get; set; } = "Available";
    public decimal capacity_kg { get; set; }
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}