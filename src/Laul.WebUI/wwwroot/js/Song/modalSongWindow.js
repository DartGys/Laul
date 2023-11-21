function openModal(albumId) {
    Url = '/Song/GetSongListForm';
    const modal = new bootstrap.Modal(document.getElementById('modal'));

    $.ajax({
        type: 'GET',
        url: Url,
        data: { AlbumId: albumId },
        success: function (response) {
            console.log("Modal success");
            modal._element.querySelector(".modal-title").textContent = "Song`s List";
            modal._element.querySelector(".modal-body").innerHTML = response;
            modal.show();
        },
        error: function (xhr, status, error) {
            console.error("Modal failure:", status, error);
            modal.hide();
        }
    });
}
