namespace RubberTradingSystem.Models;

public class TruckExpenseModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string truck_number { get; set; } = string.Empty;
    public string expense_type { get; set; } = "Fuel"; // Fuel သို့မဟုတ် Maintenance
    public decimal amount { get; set; }
    public string payment_method { get; set; } = "Cash"; // ငွေပေးချေမှု နည်းလမ်း
    public DateTime expense_date { get; set; } = DateTime.Today;
    public string? note { get; set; }
}