function previewImage(input) {
    var preview = document.getElementById('photoPreview');
    preview.innerHTML = ''; // Очистіть попереднє прев'ю

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            var image = document.createElement('img');
            image.src = e.target.result;
            image.style.maxWidth = '100%'; // Забезпечте максимальну ширину
            preview.appendChild(image);
        };

        reader.readAsDataURL(input.files[0]); // Читання файлу як URL-даних
    }
}