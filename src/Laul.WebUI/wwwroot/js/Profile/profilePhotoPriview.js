document.addEventListener("DOMContentLoaded", function () {
    var urlParams = new URLSearchParams(window.location.search);

    var photoParam = urlParams.get('Photo');

    loadCurrentImage(photoParam);
});

function loadCurrentImage(photo) {
    var preview = document.getElementById('photoPreview');

    var image = document.createElement('img');
    image.src = photo;
    image.style.maxWidth = '100%'; 
    preview.appendChild(image);
}

function previewImage(input) {
    var preview = document.getElementById('photoPreview');
    preview.innerHTML = ''; 

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            var image = document.createElement('img');
            image.src = e.target.result;
            image.style.maxWidth = '100%';
            preview.appendChild(image);
        };

        reader.readAsDataURL(input.files[0]); // Читання файлу як URL-даних
    }
}