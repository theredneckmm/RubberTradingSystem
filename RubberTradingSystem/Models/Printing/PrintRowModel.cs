namespace RubberTradingSystem.Models.Printing;

public class PrintRowModel
{
    public string Description { get; set; } = "";

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal Amount { get; set; }
}