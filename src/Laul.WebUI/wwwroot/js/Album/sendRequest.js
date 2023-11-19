function sendAlbumRequest() {
    const modal = new bootstrap.Modal(document.getElementById('modal'));

    var albumDto = {
        ArtistId: $('#ArtistId').val(),
        Title: $('#Title').val(),
        Image: $('#Image')[0].files[0],
        PublishDate: $('#PublishDate').val(),
        Genre: $('#Genre').val()
    };

    $.ajax({
        url: '/Album/CreateAlbum',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(albumDto),
        success: function (data) {
            console.log('Success:', data);
            modal.hide()
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}