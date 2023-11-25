function deletePlaylist(PlaylistId) {
    $.ajax({
        url: '/Playlist/DeletePlaylist',
        method: 'DELETE',
        data: {
            PlaylistId: PlaylistId
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

function changeCursor(element) {
    element.style.cursor = "pointer";
}