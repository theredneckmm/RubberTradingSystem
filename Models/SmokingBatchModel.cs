namespace RubberTradingSystem.Models;

public class SmokingBatchModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string batch_no { get; set; } = $"SM-{DateTime.Now:yyyyMMdd}-{new Random().Next(100, 999)}";
    public string warehouse_name { get; set; } = string.Empty; // မှိုင်းတိုက်ရှိရာ ဂိုဒေါင်
    public string rubber_type_input { get; set; } = string.Empty; // ထည့်မည့်အစိုတုံး အမျိုးအစား
    public string rubber_type_output { get; set; } = string.Empty; // ထွက်လာမည့်အခြောက် အမျိုးအစား
    public decimal input_weight_kg { get; set; }
    public decimal? output_weight_kg { get; set; }
    public DateTime start_date { get; set; } = DateTime.Today;
    public DateTime? end_date { get; set; }
    public string status { get; set; } = "Smoking"; // Smoking, Completed
    public decimal shrinkage_kg => output_weight_kg.HasValue ? input_weight_kg - output_weight_kg.Value : 0;
    public decimal shrinkage_percentage => (input_weight_kg > 0 && output_weight_kg.HasValue) ? ((input_weight_kg - output_weight_kg.Value) / input_weight_kg) * 100 : 0;
    public string? note { get; set; }
}