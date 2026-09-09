using System;
using System.Text.Json.Serialization;

namespace RubberTradingSystem.Models
{
    public class ExpenseSettingModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; } = string.Empty;

        [JsonPropertyName("staff_id")]
        public string? StaffId { get; set; }

        [JsonPropertyName("setting_type")]
        public string SettingType { get; set; } = "Category"; // 'Category' သို့မဟုတ် 'Title'

        [JsonPropertyName("setting_name")]
        public string SettingName { get; set; } = string.Empty;

        [JsonPropertyName("category_id")]
        public string? CategoryId { get; set; } // Title ဖြစ်လျှင် သက်ဆိုင်ရာ Category ရဲ့ ID

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}