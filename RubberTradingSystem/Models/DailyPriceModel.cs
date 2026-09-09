namespace RubberTradingSystem.Models;

public class DailyPriceModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string? staff_id { get; set; }
    public string rubber_type_id { get; set; } = string.Empty;
    public decimal price_per_unit { get; set; }
    public DateTime effective_date { get; set; } = DateTime.Today;
    public DateTime created_at { get; set; } = DateTime.UtcNow;
    public RubberTypeModel? rubber_types { get; set; }
}