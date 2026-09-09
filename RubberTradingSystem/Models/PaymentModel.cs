namespace RubberTradingSystem.Models;

public class PaymentModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string supplier_name { get; set; } = string.Empty;
    public decimal amount_paid { get; set; }
    public DateTime payment_date { get; set; } = DateTime.Today;
    public string payment_method { get; set; } = "Cash";
    public string? reference_no { get; set; }
    public string? note { get; set; }
}