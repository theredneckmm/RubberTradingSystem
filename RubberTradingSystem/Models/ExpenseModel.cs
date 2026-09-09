using System;
using System.Text.Json.Serialization;

namespace RubberTradingSystem.Models
{
    public class ExpenseModel
    {
        [JsonPropertyName("id")]
        public string id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("owner_id")]
        public string owner_id { get; set; } = string.Empty;

        [JsonPropertyName("staff_id")]
        public string? staff_id { get; set; }

        [JsonPropertyName("category")]
        public string category { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string title { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal amount { get; set; }

        [JsonPropertyName("payment_method")]
        public string payment_method { get; set; } = "Cash";

        [JsonPropertyName("expense_date")]
        public DateTime expense_date { get; set; } = DateTime.Today;

        [JsonPropertyName("note")]
        public string? note { get; set; }
    }
}