function deleteAlbum(AlbumId) {
    $.ajax({
        url: '/Album/DeleteAlbum',
        method: 'DELETE',
        data: {
            AlbumId: AlbumId
        },
        success: function (data) {
            console.log('success delete');
            location.reload();
        },
        error: function (data) {
            console.log('error deleting ' + data);
        }
    })
}