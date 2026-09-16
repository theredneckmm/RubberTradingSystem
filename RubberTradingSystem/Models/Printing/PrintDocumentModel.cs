namespace RubberTradingSystem.Models.Printing;

public class PrintDocumentModel
{
    public string Title { get; set; } = "";

    public string DocumentType { get; set; } = "";

    public string PaperSize { get; set; } = "A6";

    public int CustomWidth { get; set; } = 105;

    public int CustomHeight { get; set; } = 148;


    public string HeaderTitle { get; set; } = "";

    public string HeaderAddress { get; set; } = "";

    public string FooterNote { get; set; } = "";


    public List<PrintRowModel> Rows { get; set; } = new();


    public List<PrintFieldModel> Fields { get; set; } = new();
}