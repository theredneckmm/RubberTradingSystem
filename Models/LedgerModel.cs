namespace RubberTradingSystem.Models;

public class LedgerModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string? staff_id { get; set; }
    public string contact_id { get; set; } = string.Empty;
    public string? transaction_id { get; set; }
    public string? voucher_number { get; set; }
    public decimal debit_amount { get; set; } = 0.00m;   // 👈 ငွေထွက် / ပေးရန်လျော့
    public decimal credit_amount { get; set; } = 0.00m;  // 👈 ငွေဝင် / ပေးရန်တက်
    public decimal balance_after { get; set; } = 0.00m;    // 👈 Running Balance
    public string? ref_type { get; set; }                // ဥပမာ - 'Purchase', 'AdvanceIn', 'AdvanceOut'
    public string? description { get; set; }
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}