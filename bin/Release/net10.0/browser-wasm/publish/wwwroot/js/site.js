// wwwroot/js/site.js
window.downloadFileFromByteArray = (fileName, contentType, bytearray) => {
    const blob = new Blob([new Uint8Array(bytearray)], { type: contentType });
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName;
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
};