using System.Text.Json.Serialization;

namespace RubberTradingSystem.Models;

public class StaffModel
{
    public string id { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;

    [JsonPropertyName("full_name")] 
    public string? full_name { get; set; }

    public string? role { get; set; } = "Staff";
}