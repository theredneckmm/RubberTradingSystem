using System.Text.Json.Serialization;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace RubberTradingSystem.Models
{
    [Table("profiles")]
    public class Profile : BaseModel
    {
        [PrimaryKey("id", false)]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [Column("owner_id")]
        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; } = string.Empty;

        [Column("role")]
        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;

        [Column("full_name")]
        [JsonPropertyName("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Column("created_at")]
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}