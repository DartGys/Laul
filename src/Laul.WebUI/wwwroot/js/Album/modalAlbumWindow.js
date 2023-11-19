function openAlbumModal(artistId) {
    Url = '/Album/CreateAlbum'
    const modal = new bootstrap.Modal(document.getElementById('modal'));

    $.ajax({
        type: 'GET',
        url: Url,
        data: { ArtistId: artistId },
        success: function (response) {
            console.log("Modal success");
            modal._element.querySelector(".modal-title").textContent = "Create Album";
            modal._element.querySelector(".modal-body").innerHTML = response;
            modal.show();
        },
        error: function (xhr, status, error) {
            console.error("Modal failure:", status, error);
            modal.hide();
        }
    });
}
