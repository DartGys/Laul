function sendAlbumRequest() {
    const modal = new bootstrap.Modal(document.getElementById('modal'));
    var succedContainer = $('#succedContainer');

    var formData = new FormData();
    formData.append('ArtistId', $('#ArtistId').val());
    formData.append('Title', $('#Title').val());
    formData.append('Image', $('#Image')[0].files[0]);
    formData.append('PublishDate', $('#PublishDate').val());
    formData.append('Genre', $('#Genre').val());

    $.ajax({
        url: '/Album/CreateAlbum',
        method: 'POST',
        processData: false,
        contentType: false,
        data: formData,
        success: function (data) {
            console.log('Success:', data);
            modal.hide();  // Закрити модальне вікно при успіху
            succedContainer.append('<div>' + 'Album was created succesful' + '</div>');
        },
        error: function (error) {
            console.error('Error:', error);

            // Очистити попередні помилки
            succedContainer.html('');

            succedContainer.append('<div>' + error.responseText + '</div>');
        }
    });
}
