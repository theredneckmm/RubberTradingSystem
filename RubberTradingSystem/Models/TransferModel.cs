using System;
using System.Text.Json.Serialization;

namespace RubberTradingSystem.Models
{
    public class TransferModel
    {
        [JsonPropertyName("id")]
        public string id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("owner_id")]
        public string owner_id { get; set; } = string.Empty;

        [JsonPropertyName("staff_id")]
        public string? staff_id { get; set; }

        [JsonPropertyName("from_wallet_id")]
        public string from_wallet_id { get; set; } = string.Empty;

        [JsonPropertyName("from_wallet_name")]
        public string from_wallet_name { get; set; } = string.Empty;

        [JsonPropertyName("to_wallet_id")]
        public string to_wallet_id { get; set; } = string.Empty;

        [JsonPropertyName("to_wallet_name")]
        public string to_wallet_name { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal amount { get; set; }

        [JsonPropertyName("transfer_date")]
        public DateTime transfer_date { get; set; } = DateTime.Today;

        [JsonPropertyName("note")]
        public string? note { get; set; }
    }
}