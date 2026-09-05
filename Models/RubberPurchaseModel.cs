namespace RubberTradingSystem.Models;

public class RubberPurchaseModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string? staff_id { get; set; }

    // 🔗 Foreign Keys / IDs
    public string? contact_id { get; set; }
    public string? rubber_type_id { get; set; }
    public string? truck_id { get; set; }
    public string? wallet_id { get; set; } 

    public string transaction_type { get; set; } = "Purchase";
    public string purchase_location { get; set; } = "Truck";

    // 📌 Dialog နှင့် Page များတွင် အသုံးပြုသော အမည်များ
    public string? supplier_name { get; set; }
    public string? rubber_type { get; set; }

    public decimal price_per_unit { get; set; }
    public decimal base_price { get; set; }
    public decimal service_cost { get; set; }
    public decimal deduction_percent { get; set; }

    public decimal agreed_price => ((price_per_unit > 0 ? price_per_unit : base_price) - service_cost) * (1m - (deduction_percent / 100m));

    public decimal weight { get; set; }
    public decimal quantity { get; set; }

    public decimal total_amount => agreed_price * (weight > 0 ? weight : quantity);
    public string? voucher_number { get; set; }

    public decimal advance_amount { get; set; } = 0;
    public decimal net_payable => total_amount - advance_amount;
    public decimal actual_paid { get; set; }

    public DateTime purchase_date { get; set; } = DateTime.Now;
}