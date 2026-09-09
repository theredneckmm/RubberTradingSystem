using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RubberTradingSystem.Models;

public class FarmOwner
{
    // Supabase က Auto ထုတ်ပေးမှာမို့လို့ Insert လုပ်ချိန်မှာ မပါလည်းရအောင်
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int id { get; set; }

    [Required(ErrorMessage = "ခြံရှင်အမည် ထည့်သွင်းရန် လိုအပ်ပါသည်။")]
    public string name { get; set; } = string.Empty;

    [Required(ErrorMessage = "ဖုန်းနံပါတ် ထည့်သွင်းရန် လိုအပ်ပါသည်။")]
    [Phone(ErrorMessage = "ဖုန်းနံပါတ် ပုံစံမမှန်ပါ။")]
    public string phone { get; set; } = string.Empty;

    public string? address { get; set; }
}