function previewImage(input) {
    var preview = document.getElementById('photoPreview');
    preview.innerHTML = ''; // ������� �������� ����'�

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            var image = document.createElement('img');
            image.src = e.target.result;
            image.style.maxWidth = '100%'; // ���������� ����������� ������
            preview.appendChild(image);
        };

        reader.readAsDataURL(input.files[0]); // ������� ����� �� URL-�����
    }
}