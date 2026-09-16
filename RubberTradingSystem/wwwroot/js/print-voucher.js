window.printVoucher = function (
    elementId,
    paperSize,
    customWidth,
    customHeight
) {
    const element = document.getElementById(elementId);
    if (!element) {
        console.error("Print element not found: " + elementId);
        return;
    }

    let paperWidth = customWidth;
    let paperHeight = customHeight;

    // Fallback switch just in case
    if (paperSize === "A4_Portrait") { paperWidth = 210; paperHeight = 297; }
    else if (paperSize === "A4_Landscape") { paperWidth = 297; paperHeight = 210; }
    else if (paperSize === "A5_Portrait") { paperWidth = 148; paperHeight = 210; }
    else if (paperSize === "A5_Landscape") { paperWidth = 210; paperHeight = 148; }
    else if (paperSize === "A6_Portrait") { paperWidth = 105; paperHeight = 148; }
    else if (paperSize === "A6_Landscape") { paperWidth = 148; paperHeight = 105; }
    else if (paperSize === "Thermal_80mm") { paperWidth = 80; paperHeight = 200; }

    const printWindow = window.open("", "_blank", "width=900,height=800");
    if (!printWindow) {
        alert("Print Window ကို Browser က ပိတ်ထားပါတယ်။ Popup ကို Allow လုပ်ပေးပါ။");
        return;
    }

    const content = element.innerHTML;

    printWindow.document.open();
    printWindow.document.write(`
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Voucher Print</title>
<style>
@page {
    size: ${paperWidth}mm ${paperHeight}mm;
    margin: 0;
}
* { box-sizing: border-box; }
html, body {
    margin: 0 !important;
    padding: 0 !important;
    background: white !important;
    color: black !important;
    font-family: "Noto Sans Myanmar", "Myanmar Text", Arial, sans-serif;
}
.voucher-paper {
    width: ${paperWidth}mm !important;
    height: ${paperHeight}mm !important;
    min-height: ${paperHeight}mm !important;
    max-height: ${paperHeight}mm !important;
    margin: 0 !important;
    padding: 6mm !important;
    background: white !important;
    color: black !important;
    display: flex !important;
    flex-direction: column !important;
    justify-content: space-between !important;
    overflow: hidden !important;
}
.voucher-header { text-align: center; margin-bottom: 10px; }
.voucher-title { font-size: 18px; font-weight: bold; margin-bottom: 2px; }
.voucher-address { font-size: 11px; color: #444; white-space: pre-line; }
.voucher-header-line { border-bottom: 2px solid #000; margin-top: 6px; margin-bottom: 10px; }
.voucher-meta { font-size: 13px; margin-bottom: 10px; }
.voucher-table { width: 100%; border-collapse: collapse; margin-bottom: 15px; font-size: 12px; }
.voucher-table th { padding: 6px; text-align: left; border-top: 1px solid #000; border-bottom: 2px solid #000; font-weight: bold; }
.voucher-table td { padding: 6px; border-bottom: 1px solid #ddd; vertical-align: top; }
.voucher-footer { text-align: center; margin-top: auto; font-size: 12px; }
</style>
</head>
<body>
<div class="voucher-paper">
    ${content}
</div>
<script>
window.onload = function () {
    setTimeout(function () { window.print(); }, 500);
};
window.onafterprint = function () {
    setTimeout(function () { window.close(); }, 300);
};
</script>
</body>
</html>
    `);
    printWindow.document.close();
};