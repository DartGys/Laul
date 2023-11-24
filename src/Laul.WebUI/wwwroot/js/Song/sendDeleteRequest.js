function deleteRequest(SongId) {
    $.ajax({
        url: '/Song/DeleteSong',
        method: 'DELETE',
        data: {
            SongId: SongId
        },
        success: function (data) {
            console.log('Success delete');

            location.reload();
        },
        error: function (data) {
            console.log('Failed delete');
        }
    });
}
