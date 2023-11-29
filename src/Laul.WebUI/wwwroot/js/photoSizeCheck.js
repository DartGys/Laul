function photoSize() {
    var fileInput = document.getElementById('photoInput');
    var maxFileSizeMB = 2;

    if (fileInput.files.length > 0) {
        var fileSizeMB = fileInput.files[0].size / (1024 * 1024); // Розмір у мегабайтах

        if (fileSizeMB > maxFileSizeMB) {
            alert('The file size exceeds the maximum allowed (2 MB).');
            fileInput.value = '';
        }
        else {
            previewImage(fileInput);
        }
    }
}