document.addEventListener("DOMContentLoaded", function () {
    var artist = document.getElementById("artistInfo");
    var artistId = artist.dataset.artistId;

    getCount(artistId);
});

function getCount(ArtistId) {
    var listeningDiv = $('#listening');

    $.ajax({
        url: '/ListeningStat/GetListeningStatCount',
        data: { ArtistId: ArtistId },
        success: function (data) {
            listeningDiv.html(data + ' listenings')
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}