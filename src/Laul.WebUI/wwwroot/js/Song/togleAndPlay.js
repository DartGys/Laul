function toggleAndPlayAudio(audioUrl, storage) {
    console.log('Playing song:', audioUrl);
    // Отримайте доступ до елементу аудіо та змініть його src
    var audioPlayer = document.getElementById('footerAudioPlayer');

    var same = audioPlayer.src === storage;
    // Перевірте, чи аудіо відтворюється
    if (same && !audioPlayer.paused) {
        // Якщо так, поставте на паузу
        audioPlayer.pause();
    }
    else if (same && audioPlayer.paused){
        audioPlayer.play();
    }
    else {
        // Інакше встановіть новий src та відтворіть
        audioPlayer.src = audioUrl;
        audioPlayer.play();

        // Покажіть футер (можливо, змінюючи його стиль)
        var footer = document.getElementById('footer');
        footer.style.display = 'block';
    }
}

function changeCursor(element) {
    element.style.cursor = "pointer";
}
