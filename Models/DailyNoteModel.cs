namespace RubberTradingSystem.Models;

public class DailyNoteModel
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string owner_id { get; set; } = string.Empty;
    public string title { get; set; } = string.Empty;
    public string content { get; set; } = string.Empty;
    public DateTime note_date { get; set; } = DateTime.Today;
}