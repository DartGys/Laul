var audioPlayer = document.getElementById('footerAudioPlayer');

var storedVolume = localStorage.getItem('audioVolume');
if (storedVolume !== null) {
    audioPlayer.volume = parseFloat(storedVolume);
}

audioPlayer.addEventListener('volumechange', function () {
    localStorage.setItem('audioVolume', audioPlayer.volume.toString());
});