function deleteArtist(ArtistId) {
    $.ajax({
        url: '/Profile/DeleteArtist',
        method: 'DELETE',
        data: {
            ArtistId: ArtistId
        },
        success: function (data) {
            console.log('delete success');
            location.reload();
        },
        error: function (data) {
            console.log('error delete ' + data);
        }
    })
}