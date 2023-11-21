function addSelectedSongs(AlbumId) {
    var selectedSongs = [];

    // Знаходження обраних пісень
    $('.songCheckbox:checked').each(function () {
        selectedSongs.push($(this).data('song-id'));
    });

    $.ajax({
        url: '/Song/AddSongToAlbum', 
        type: 'POST',
        data: { SongsId: selectedSongs, AlbumId: AlbumId }, 

        success: function (data) {
            console.log('Успішно відправлено на сервер:', data);

            location.reload();
        },
        error: function (error) {
            console.error('Помилка відправлення на сервер:', error);
        }
    });
}
