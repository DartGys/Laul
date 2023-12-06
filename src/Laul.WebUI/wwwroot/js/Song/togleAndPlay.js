var songData = [];
var curSong = -1;
var audioPlayer;
var songs = [];
var UserName;
var choosenSong;

document.addEventListener("DOMContentLoaded", function () {
    audioPlayer = document.getElementById('footerAudioPlayer');
    audioPlayer.addEventListener('ended', function () {
        nextSong();
    });
});

function nextSong() {
    if (curSong < songData.length - 1) {
        var nextSong = songData[++curSong]
        if (nextSong !== undefined) {
            playSong(nextSong);
        }
    }
}

function prevSong() {
    if (curSong > 0) {
        var prevSong = songData[--curSong]
        if (prevSong !== undefined) {
            playSong(prevSong);
        }
    }
}

function toggleAndPlayAudio(SongId, shuffle = false) {
    var info = document.getElementById("songs-container");
    UserName = info.dataset.user;
    songs = JSON.parse(info.dataset.songs);

    curSong = -1;
    choosenSong = songs.find(function (onesong) {
        curSong++;
        return onesong.id === SongId;
    });

    playSong(choosenSong);

    if (shuffle) {
        shuffledSong(SongId);
    }
    else {
        unshuffledSong();
    }
}

function shuffledSong(SongId) {
    curSong = 0;
    songData = songs.filter(function (onesong) {
        return onesong.id !== SongId;
    });

    shuffleArray(songData);

    songData.unshift(choosenSong);
}

function unshuffledSong() {
    songData = songs;
}

function shuffleSong() {
    if (curSong + 1 < songData.length) {
        var dataToShuffle = songData.slice(curSong + 1);
        shuffleArray(dataToShuffle);
        songData.splice(curSong + 1, songData.length);
        songData = songData.concat(dataToShuffle);
    }
}

function playSong(song) {

    if (!!UserName) {
        localStorage.removeItem('SongId');
        localStorage.removeItem('ArtistName');
        localStorage.setItem('SongId', song.id);
        localStorage.setItem('ArtistName', UserName);


        getLikeDislike(song.id, UserName);
    }

    updateFooterInfo(song.title, song.artistName, song.albumTitle, song.photo);

    var same = audioPlayer.src === song.storage;
    // Перевірка, чи аудіо відтворюється
    if (same && !audioPlayer.paused) {
        // Якщо так,  паузу
        audioPlayer.pause();
    }
    else if (same && audioPlayer.paused) {
        audioPlayer.play();
    }
    else {
        // Інакше  новий src
        audioPlayer.src = song.storage;
        audioPlayer.play();

        var footer = document.getElementById('footer');
        footer.style.display = 'block';
         if (!!UserName) {
             sendListeningStat(song.id, UserName);
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
