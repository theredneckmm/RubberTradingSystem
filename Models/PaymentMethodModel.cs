namespace RubberTradingSystem.Models;

public class PaymentMethodModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string name { get; set; } = string.Empty;       
    public string type { get; set; } = string.Empty; 
    public string account_details { get; set; } = string.Empty; 
    public bool is_active { get; set; } = true;
}