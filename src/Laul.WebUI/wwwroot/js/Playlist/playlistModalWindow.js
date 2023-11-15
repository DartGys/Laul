function openModal(songId) {
    const url = '/Playlist/GetPlaylistListForm';
    const modal = $('#modal');

    if (!modal.length) {
        alert('Error')
        return;
    }

    $.ajax({
        type: 'GET',
        url: url,
        data: { Songid : songId },
        success: function (response) {
            console.log("modal success");
            modal.find(".modal-body").html(response);
            modal.modal('show')
        },
        error: function () {
            console.log("modal failure")
            modal.modal('hide')
        },
        error: function (response) {
            alert(response.responseText)
        }
    });
}