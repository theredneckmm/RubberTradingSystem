namespace RubberTradingSystem.Models;

public class RubberTypeModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string? staff_id { get; set; } 
    public string name { get; set; } = string.Empty;
    public string grade { get; set; } = string.Empty;
    public string? description { get; set; }
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}