namespace RubberTradingSystem.Models;

public class EmployeeModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty; // owner_id ပါဝင်အောင် ထည့်သွင်းထားပါသည်
    public string full_name { get; set; } = string.Empty;
    public string position { get; set; } = string.Empty;
    public decimal salary { get; set; }
    public string phone { get; set; } = string.Empty;
    public string address { get; set; } = string.Empty;
    public DateTime hire_date { get; set; } = DateTime.Today;
    public string status { get; set; } = "Active";
}