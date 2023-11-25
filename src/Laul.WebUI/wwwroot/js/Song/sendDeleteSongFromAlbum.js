function deleteSongFromAlbum(SongId) {
    $.ajax({
        url: '/Song/DeleteSongFromAlbum',
        method: 'DELETE',
        data: {
            SongId: SongId
        },
        success: function (data) {
            console.log('delete from album success');
            location.reload()
        },
        error: function (data) {
            console.log('error deleting ' + data);
        }
    })
}