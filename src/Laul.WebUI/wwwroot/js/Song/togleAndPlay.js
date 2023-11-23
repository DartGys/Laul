function toggleAndPlayAudio(audioUrl, SongId, ArtistName) {
    console.log('Playing song:', audioUrl);
    var audioPlayer = document.getElementById('footerAudioPlayer');

    if (!!ArtistName) {
        localStorage.removeItem('SongId');
        localStorage.removeItem('ArtistName');
        localStorage.setItem('SongId', SongId);
        localStorage.setItem('ArtistName', ArtistName);


        getLikeDislike(SongId, ArtistName);
    }

    var same = audioPlayer.src === audioUrl;
    // Перевірка, чи аудіо відтворюється
    if (same && !audioPlayer.paused) {
        // Якщо так,  паузу
        audioPlayer.pause();
    }
    else if (same && audioPlayer.paused){
        audioPlayer.play();
    }
    else {
        // Інакше  новий src
        audioPlayer.src = audioUrl;
        audioPlayer.play();

        var footer = document.getElementById('footer');
        footer.style.display = 'block';
         if (!!ArtistName) {
            sendListeningStat(SongId, ArtistName)
         }
    }
}

function changeCursor(element) {
    element.style.cursor = "pointer";
}

function sendListeningStat(SongId, ArtistName) {
    $.ajax({
        url: '/ListeningStat/CreateListeningStat',
        data: {
            SongId: SongId,
            ArtistName: ArtistName
        },
        success: function (data) {
            console.log('Success:', data);
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}
