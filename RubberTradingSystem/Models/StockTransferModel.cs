namespace RubberTradingSystem.Models;

public class StockTransferModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string transfer_no { get; set; } = $"TR-{DateTime.Now:yyyyMMdd}-{new Random().Next(100, 999)}";
    public string from_location { get; set; } = string.Empty; // Warehouse သို့မဟုတ် Truck No
    public string to_location { get; set; } = string.Empty;   // Destination Warehouse
    public string rubber_type { get; set; } = string.Empty;
    public decimal weight_kg { get; set; }
    public DateTime transfer_date { get; set; } = DateTime.Today;
    public string? note { get; set; }
}