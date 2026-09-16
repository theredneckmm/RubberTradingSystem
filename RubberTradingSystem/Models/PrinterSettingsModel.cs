namespace RubberTradingSystem.Models;

public class PrinterSettingsModel
{
    public string? voucher_size { get; set; }

    public int custom_width { get; set; }

    public int custom_height { get; set; }

    public string? header_title { get; set; }

    public string? header_address { get; set; }

    public string? footer_note { get; set; }
}