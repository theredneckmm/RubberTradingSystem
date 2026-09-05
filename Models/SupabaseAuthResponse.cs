using System.Text.Json.Serialization;

namespace RubberTradingSystem.Models;

public class SupabaseAuthResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string? Email { get; set; }
}