function songSize() {
    var fileInput = document.getElementById('songInput');
    var maxFileSizeMB = 12;

    if (fileInput.files.length > 0) {
        var fileSizeMB = fileInput.files[0].size / (1024 * 1024); // Розмір у мегабайтах

        if (fileSizeMB > maxFileSizeMB) {
            alert('The file size exceeds the maximum allowed (12 MB).');
            fileInput.value = '';
        }
    }
}