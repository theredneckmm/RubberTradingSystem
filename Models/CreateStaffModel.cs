using System.ComponentModel.DataAnnotations;

namespace RubberTradingSystem.Models;

public class CreateStaffModel
{
    [Required(ErrorMessage = "အမည် ထည့်ရန် လိုအပ်ပါသည်။")]
    public string name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email ထည့်ရန် လိုအပ်ပါသည်။")]
    [EmailAddress(ErrorMessage = "Email ပုံစံ မမှန်ပါ။")]
    public string email { get; set; } = string.Empty;

    [Required(ErrorMessage = "စကားဝှက် ထည့်ရန် လိုအပ်ပါသည်။")]
    [MinLength(6, ErrorMessage = "စကားဝှက် အနည်းဆုံး ၆ လုံး ရှိရပါမည်။")]
    public string password { get; set; } = string.Empty;
}