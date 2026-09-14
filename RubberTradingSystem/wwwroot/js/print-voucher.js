window.printVoucher = function (elementId, paperSize, customWidth, customHeight) {

    const element = document.getElementById(elementId);

    if (!element) {
        console.error("Print element not found: " + elementId);
        return;
    }

    let pageSize = "A5 portrait";

    if (paperSize === "A4") {
        pageSize = "A4 portrait";
    }
    else if (paperSize === "A5") {
        pageSize = "A5 portrait";
    }
    else if (paperSize === "A6") {
        pageSize = "A6 portrait";
    }
    else if (paperSize === "Custom") {
        pageSize = customWidth + "mm " + customHeight + "mm";
    }

    const printWindow = window.open(
        "",
        "_blank",
        "width=900,height=700"
    );

    if (!printWindow) {
        alert("Print window ကို Browser က ပိတ်ထားပါတယ်။ Popup ကို Allow လုပ်ပေးပါ။");
        return;
    }

    const content = element.innerHTML;

    printWindow.document.write(`
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">

<title>Voucher Print</title>

<style>

@page {
    size: ${pageSize};
    margin: 5mm;
}

* {
    box-sizing: border-box;
}

html,
body {
    margin: 0;
    padding: 0;
    background: white;
    color: black;
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

.voucher-paper {
    width: 100%;
    margin: 0;
    padding: 0;
    border: none;
    box-shadow: none;
    background: white;
    color: black;
}

.voucher-header {
    text-align: center;
    margin-bottom: 12px;
}

.voucher-title {
    font-size: 20px;
    font-weight: bold;
}

.voucher-address {
    font-size: 12px;
    white-space: pre-line;
}

.voucher-header-line {
    border-bottom: 2px solid #000;
    margin-top: 8px;
    margin-bottom: 12px;
}

.voucher-meta {
    display: flex;
    justify-content: space-between;
    margin-bottom: 12px;
}

.voucher-details {
    margin-bottom: 15px;
}

.voucher-table {
    width: 100%;
    border-collapse: collapse;
    margin-bottom: 18px;
}

.voucher-table th {
    padding: 7px 6px;
    text-align: left;
    border-top: 1px solid #000;
    border-bottom: 2px solid #000;
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

.voucher-description {
    margin-top: 10px;
    margin-bottom: 25px;
}

.voucher-footer {
    text-align: center;
    border-top: 1px dashed #777;
    padding-top: 12px;
    margin-top: 30px;
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