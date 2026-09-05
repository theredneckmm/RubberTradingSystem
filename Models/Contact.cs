using System;
using System.Text.Json.Serialization;

namespace RubberTradingSystem.Models
{
    // BaseModel နှင့် Supabase Attributes များကို ဖယ်ရှားလိုက်ပါသည်
    public class Contact
    {
        // JSON ဖြင့် အဝင်/အထွက် လုပ်ရာတွင် Database Column အမည်နှင့် ချိတ်ဆက်ပေးခြင်း
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        [JsonPropertyName("contact_type")]
        public string ContactType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("advance_balance")]
        public decimal AdvanceBalance { get; set; }

        [JsonPropertyName("receivable_balance")]
        public decimal ReceivableBalance { get; set; }

        [JsonPropertyName("bank_info")]
        public string BankInfo { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}