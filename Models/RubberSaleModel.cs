namespace RubberTradingSystem.Models;

public class RubberSaleModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string invoice_no { get; set; } = $"INV-{DateTime.Now:yyyyMMdd}-{new Random().Next(100, 999)}";
    public string customer_name { get; set; } = string.Empty;
    public string warehouse_name { get; set; } = string.Empty;
    public string rubber_type { get; set; } = string.Empty;
    public decimal weight_kg { get; set; }
    public decimal price_per_kg { get; set; }
    public decimal total_amount => weight_kg * price_per_kg; // အလိုအလျောက် တွက်ချက်ပေးမည်
    public string payment_method { get; set; } = "Cash";
    public DateTime sale_date { get; set; } = DateTime.Today;
    public string? note { get; set; }
}