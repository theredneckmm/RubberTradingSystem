using Microsoft.JSInterop;
using MudBlazor;
using RubberTradingSystem.Components;
using RubberTradingSystem.Models.Printing;

namespace RubberTradingSystem.Services;

public class PrintService
{
    private readonly IDialogService _dialogService;
    private readonly IJSRuntime _jsRuntime; // IJSRuntime ကို ထည့်သွင်းပါ

    public PrintService(IDialogService dialogService, IJSRuntime jsRuntime)
    {
        _dialogService = dialogService;
        _jsRuntime = jsRuntime;
    }

    public async Task ShowPrintPreview(PrintDocumentModel document)
    {
        var parameters = new DialogParameters
        {
            ["Document"] = document
        };

        var options = new DialogOptions
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            CloseButton = true,
            CloseOnEscapeKey = true
        };

        await _dialogService.ShowAsync<PrintPreviewDialog>
        (
            document.Title,
            parameters,
            options
        );
    }

    // JavaScript ထဲက printVoucher ကို တိုက်ရိုက်လှမ်းခေါ်မည့် Method
    public async Task TriggerPrintAsync(string elementId, PrintDocumentModel document)
    {
        await _jsRuntime.InvokeVoidAsync(
            "printVoucher",
            elementId,
            document.PaperSize,
            document.CustomWidth,
            document.CustomHeight
        );
    }
}