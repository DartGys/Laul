function sendPlaylistRequest(songId, playlistId) {
    const modal = $('#modal');
    var succedContainer = $('#succedContainer');


    $.ajax({
        url: '/PlaylistSong/AddSongToPlaylist',
        method: 'POST',
        data: { SongId: songId, PlaylistId: playlistId },
        success: function (data) {
            console.log('Success:', data);
            $('#modal').modal('hide')
            succedContainer.append('<div style="color: green;">' + 'Song was added to playlist' + '</div>');

        },
        error: function (error) {
            console.error('Error:', error);
            succedContainer.html('');
            succedContainer.append('<div style="color: red;">' + 'Song already in playlist' + '</div>');
        }
    });
}