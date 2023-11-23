function toggleLike(element) {
    if (element.classList.contains("bx-like")) {
        element.classList.remove("bx-like");
        element.classList.add("bxs-like");
    } else if (element.classList.contains("bxs-like")) {
        element.classList.remove("bxs-like");
        element.classList.add("bx-like");
        sendLikeOrDislikeRequest(true, 'DeleteLikeDislike');
        return;
    }

    var dislikeButton = document.getElementById('dislikeButton'); // Замініть 'dislikeButton' на id вашої кнопки дізлайка
    if (dislikeButton.classList.contains("bxs-dislike")) {
        dislikeButton.classList.remove("bxs-dislike");
        dislikeButton.classList.add("bx-dislike");
        sendLikeOrDislikeRequest(true, 'UpdateLikeDislike');
        return;
    }

    sendLikeOrDislikeRequest(true, 'CreateLikeDislike');
}

function toggleDisLike(element) {
    if (element.classList.contains("bx-dislike")) {
        element.classList.remove("bx-dislike");
        element.classList.add("bxs-dislike");
    } else if (element.classList.contains("bxs-dislike")) {
        element.classList.remove("bxs-dislike");
        element.classList.add("bx-dislike");
        sendLikeOrDislikeRequest(false, 'DeleteLikeDislike');
        return;
    }

    var likeButton = document.getElementById('likeButton'); // Замініть 'likeButton' на id вашої кнопки лайка
    if (likeButton.classList.contains("bxs-like")) {
        likeButton.classList.remove("bxs-like");
        likeButton.classList.add("bx-like");
        sendLikeOrDislikeRequest(false, 'UpdateLikeDislike');
        return;
    }

    sendLikeOrDislikeRequest(false, 'CreateLikeDislike');
}

function sendLikeOrDislikeRequest(isLike, request) {

    var artistName = localStorage.getItem('ArtistName');
    var songId = localStorage.getItem('SongId');
    const Url = '/LikeDislike/' + request;

    $.ajax({
        url: Url, 
        data: {
            ArtistName: artistName,
            SongId: songId,
            isLike: isLike
        },
        success: function (data) {
            console.log('ListeningAdded:', data);
        },
        error: function (error) {
            console.error('ErrorListening:', error);
        }
    });
}



function addHoverEffect(element) {
    element.classList.add("bx-tada");
}

function removeHoverEffect(element) {
    element.classList.remove("bx-tada");
}