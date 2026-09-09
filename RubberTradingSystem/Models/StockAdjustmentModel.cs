namespace RubberTradingSystem.Models;

public class StockAdjustmentModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string adjustment_no { get; set; } = $"ADJ-{DateTime.Now:yyyyMMdd}-{new Random().Next(100, 999)}";
    public string warehouse_name { get; set; } = string.Empty;
    public string rubber_type { get; set; } = string.Empty;
    public decimal system_qty_kg { get; set; }
    public decimal actual_qty_kg { get; set; }
    public decimal difference_kg => actual_qty_kg - system_qty_kg; // အလိုအလျောက် တွက်ချက်မည် (+/-)
    public DateTime adjustment_date { get; set; } = DateTime.Today;
    public string reason { get; set; } = "Shrinkage / Weight Loss";
    public string? note { get; set; }
}