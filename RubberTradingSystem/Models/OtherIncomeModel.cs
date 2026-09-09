using System;
using System.Text.Json.Serialization;

namespace RubberTradingSystem.Models
{
    public class OtherIncomeModel
    {
        [JsonPropertyName("id")]
        public string id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("owner_id")]
        public string owner_id { get; set; } = string.Empty;

        [JsonPropertyName("staff_id")]
        public string? staff_id { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal amount { get; set; }

        [JsonPropertyName("received_date")]
        public DateTime received_date { get; set; } = DateTime.Today;

        [JsonPropertyName("payment_method")]
        public string payment_method { get; set; } = "Cash";

        [JsonPropertyName("note")]
        public string? note { get; set; }
    }
}