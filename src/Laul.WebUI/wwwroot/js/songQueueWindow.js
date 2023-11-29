function songQueue() {
    const modal = new bootstrap.Modal(document.getElementById('modal'));
    const Url = '/Song/SongQueue'

    songData.forEach(function (song) {
        var songElement = document.createElement('div');
        songElement.innerHTML = `
            <div>
                <img src="${song.photo}" alt="Song Photo" style="width: 50px;">
                <p>${song.title}</p>
                <p>${song.artistName}</p>
                <p>${song.albumTitle}</p>
            </div>
            <hr>
        `;
        modalBody.appendChild(songElement);
    });

    const modal = new bootstrap.Modal(document.getElementById('modal'), {});
    modal.show();
}
