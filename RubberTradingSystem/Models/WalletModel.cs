using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Text.Json.Serialization;

namespace RubberTradingSystem.Models
{
    [Table("wallets")]
    public class WalletModel : BaseModel
    {
        [PrimaryKey("id", false)]
        [JsonPropertyName("id")]
        [Column("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("owner_id")]
        [Column("owner_id")]
        public string OwnerId { get; set; } = string.Empty;

        [JsonPropertyName("staff_id")]
        [Column("staff_id")]
        public string StaffId { get; set; } = string.Empty; // ဝန်ထမ်းအလိုက် ခွဲခြားရန်

        [JsonPropertyName("wallet_type")]
        [Column("wallet_type")]
        public string WalletType { get; set; } = "Cash"; // Cash, KPay, WavePay, Bank

        [JsonPropertyName("wallet_name")]
        [Column("wallet_name")]
        public string WalletName { get; set; } = string.Empty; // ဥပမာ - KBZ (U Ba)

        [JsonPropertyName("balance")]
        [Column("balance")]
        public decimal Balance { get; set; } = 0.00m;

        [JsonPropertyName("created_at")]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}