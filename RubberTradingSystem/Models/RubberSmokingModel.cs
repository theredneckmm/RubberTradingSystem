using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RubberTradingSystem.Models
{
    public class RubberSmokingBatchModel
    {
        [JsonPropertyName("id")]
        public string id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("owner_id")]
        public string owner_id { get; set; } = string.Empty;

        [JsonPropertyName("staff_id")]
        public string? staff_id { get; set; }

        [JsonPropertyName("batch_number")]
        public string batch_number { get; set; } = string.Empty;

        [JsonPropertyName("start_date")]
        public DateTime start_date { get; set; } = DateTime.Today;

        [JsonPropertyName("end_date")]
        public DateTime? end_date { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; } = "Processing"; // Processing, Completed

        [JsonPropertyName("total_input_weight")]
        public decimal total_input_weight { get; set; }

        [JsonPropertyName("total_output_weight")]
        public decimal total_output_weight { get; set; }

        [JsonPropertyName("total_loss_weight")]
        public decimal total_loss_weight { get; set; }

        [JsonPropertyName("note")]
        public string? note { get; set; }

        // Navigation property for items (UI တွင် အသုံးပြုရန်)
        public List<RubberSmokingItemModel> items { get; set; } = new();
    }

    public class RubberSmokingItemModel
    {
        [JsonPropertyName("id")]
        public string id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("batch_id")]
        public string batch_id { get; set; } = string.Empty;

        [JsonPropertyName("contact_id")]
        public string? contact_id { get; set; }

        [JsonPropertyName("supplier_name")]
        public string supplier_name { get; set; } = string.Empty;

        [JsonPropertyName("input_weight")]
        public decimal input_weight { get; set; }

        [JsonPropertyName("output_weight")]
        public decimal output_weight { get; set; }

        [JsonPropertyName("loss_weight")]
        public decimal loss_weight { get; set; }
    }
}