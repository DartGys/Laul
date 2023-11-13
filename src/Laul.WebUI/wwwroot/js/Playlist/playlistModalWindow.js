function openModal() {
    const url = '/Playlist/GetPlaylistListForm';
    const modal = $('#modal');

    if (modal === undefined) {
        alert('Error')
        return;
    }

    $.ajax({
        type: 'GET',
        url: url,
        data: {},
        success: function (response) {
            console.log("modal success");
            modal.find(".modal-body").html(response);
            modal.modal('show')
        },
        failure: function () {
            console.log("modal failure")
            modal.modal('hide')
        },
        error: function (response) {
            alert(response.responseText)
        }
    });
}