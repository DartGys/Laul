function getLikeDislike(SongId, ArtistName) {
    $(function () {
        $.ajax({
            url: '/LikeDislike/GetLikeDislike',
            data: {
                ArtistName: ArtistName, 
                SongId: SongId     
            },
            success: function (data) {
                console.log('Success:', data);
                var likeButton = $('#likeButton');
                var dislikeButton = $('#dislikeButton');


                if (data === null) {
                    likeButton.removeClass('bx-like').removeClass('bxs-like').addClass('bx-like');
                    dislikeButton.removeClass('bx-dislike').removeClass('bxs-dislike').addClass('bx-dislike');
                }
                else if (data.isLike) {
                    likeButton.removeClass('bx-like').removeClass('bxs-like').addClass('bxs-like');
                    dislikeButton.removeClass('bx-dislike').removeClass('bxs-dislike').addClass('bx-dislike');
                }
                else if (!data.isLike) {
                    likeButton.removeClass('bx-like').removeClass('bxs-like').addClass('bx-like');
                    dislikeButton.removeClass('bx-dislike').removeClass('bxs-dislike').addClass('bxs-dislike');
                }
            },
            error: function (error) {
                console.error('Error:', error);
            }
        });
    });
}