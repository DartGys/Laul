function updateFooterInfo(title, artist, album, photo) {
    // Оновити вміст футера з інформацією про пісню
    var footerTitle = document.getElementById('footerTitle');
    var footerArtist = document.getElementById('footerArtist');
    var footerAlbum = document.getElementById('footerAlbum');
    var footerPhoto = document.getElementById('footerPhoto');

    footerTitle.innerText = title;
    footerArtist.innerText = (typeof artist !== 'undefined') ? artist : '';;
    footerAlbum.innerText = (typeof album !== 'undefined') ? album : '';
    footerPhoto.src = photo;

    // Включити відображення футера
    var footer = document.getElementById('footer');
    footer.style.display = 'block';
}