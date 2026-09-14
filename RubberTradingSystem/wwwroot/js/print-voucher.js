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


    // ==========================================
    // PAPER DIMENSIONS
    // ==========================================

    let paperWidth = 148;
    let paperHeight = 210;

    if (paperSize === "A4") {

        paperWidth = 210;
        paperHeight = 297;

    }
    else if (paperSize === "A5") {

        paperWidth = 148;
        paperHeight = 210;

    }
    else if (paperSize === "A6") {

        paperWidth = 105;
        paperHeight = 148;

    }
    else if (paperSize === "Custom") {

        paperWidth = customWidth;
        paperHeight = customHeight;

    }


    const printWindow = window.open(
        "",
        "_blank",
        "width=900,height=800"
    );


    if (!printWindow) {

        alert(
            "Print Window ကို Browser က ပိတ်ထားပါတယ်။ Popup ကို Allow လုပ်ပေးပါ။"
        );

        return;
    }


    const content = element.innerHTML;


    // ==========================================
    // PRINT WINDOW
    // ==========================================

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


* {

    box-sizing: border-box;

}


html,
body {

    margin: 0 !important;

    padding: 0 !important;

    background: white !important;

    color: black !important;

}


body {

    font-family:
        "Noto Sans Myanmar",
        "Myanmar Text",
        Arial,
        sans-serif;

    font-size: 13px;

    line-height: 1.5;

}


/* ==========================================
   EXACT PAPER SIZE
   ========================================== */

.voucher-paper {

    width: ${paperWidth}mm !important;

    height: ${paperHeight}mm !important;

    min-height: ${paperHeight}mm !important;

    max-width: ${paperWidth}mm !important;

    max-height: ${paperHeight}mm !important;

    margin: 0 !important;

    padding: 5mm !important;

    border: none !important;

    box-shadow: none !important;

    background: white !important;

    color: black !important;

    overflow: hidden !important;

}


/* ==========================================
   HEADER
   ========================================== */

.voucher-header {

    text-align: center;

    margin-bottom: 12px;

}


.voucher-title {

    font-size: 20px;

    font-weight: bold;

    margin-bottom: 3px;

}


.voucher-address {

    font-size: 12px;

    white-space: pre-line;

    color: #333;

}


.voucher-header-line {

    border-bottom: 2px solid #000;

    margin-top: 8px;

    margin-bottom: 12px;

}


/* ==========================================
   META
   ========================================== */

.voucher-meta {

    display: flex;

    justify-content: space-between;

    margin-bottom: 12px;

    font-size: 13px;

}


/* ==========================================
   DETAILS
   ========================================== */

.voucher-details {

    margin-bottom: 15px;

    font-size: 13px;

    line-height: 1.6;

}


/* ==========================================
   TABLE
   ========================================== */

.voucher-table {

    width: 100%;

    border-collapse: collapse;

    margin-bottom: 18px;

    font-size: 13px;

}


.voucher-table th {

    padding: 7px 6px;

    text-align: left;

    border-top: 1px solid #000;

    border-bottom: 2px solid #000;

    font-weight: bold;

}


.voucher-table td {

    padding: 7px 6px;

    border-bottom: 1px solid #ddd;

    vertical-align: top;

}


.voucher-table .text-right {

    text-align: right;

}


.total-amount {

    font-weight: bold;

}


/* ==========================================
   DESCRIPTION
   ========================================== */

.voucher-description {

    font-size: 13px;

    margin-top: 10px;

    margin-bottom: 25px;

}


/* ==========================================
   FOOTER
   ========================================== */

.voucher-footer {

    text-align: center;

    border-top: 1px dashed #777;

    padding-top: 12px;

    margin-top: 30px;

    font-size: 12px;

}


/* ==========================================
   PRINT
   ========================================== */

@media print {

    html,
    body {

        width: ${paperWidth}mm !important;

        height: ${paperHeight}mm !important;

        margin: 0 !important;

        padding: 0 !important;

    }


    .voucher-paper {

        width: ${paperWidth}mm !important;

        height: ${paperHeight}mm !important;

        min-height: ${paperHeight}mm !important;

        max-height: ${paperHeight}mm !important;

        margin: 0 !important;

        padding: 5mm !important;

        overflow: hidden !important;

    }

}

</style>

</head>


<body>


<div class="voucher-paper">

    ${content}

</div>


<script>

window.onload = function () {

    setTimeout(function () {

        window.print();

    }, 500);

};


window.onafterprint = function () {

    setTimeout(function () {

        window.close();

    }, 300);

};

</script>


</body>

</html>

    `);


    printWindow.document.close();

};