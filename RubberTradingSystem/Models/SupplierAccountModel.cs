namespace RubberTradingSystem.Models;

public class SupplierAccountModel
{
    public string supplier_name { get; set; } = string.Empty;
    public decimal total_purchased_amount { get; set; } // ဝယ်ထားသမျှ စုစုပေါင်းတန်ဖိုး
    public decimal total_paid_amount { get; set; }      // ပေးပြီးသမျှ စုစုပေါင်း
    public decimal balance_due => total_purchased_amount - total_paid_amount; // ကျန်ငွေ
}