namespace RubberTradingSystem.Models;

public class BusinessSettingsModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string? staff_id { get; set; }
    public string default_weight_unit { get; set; } = "Vis (ပိဿာ)";
    public decimal default_service_cost { get; set; } = 0;
    public decimal default_deduction_percent { get; set; } = 0;
    public string currency_symbol { get; set; } = "MMK";
    public bool enable_auto_advance_deduction { get; set; } = true;
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
}