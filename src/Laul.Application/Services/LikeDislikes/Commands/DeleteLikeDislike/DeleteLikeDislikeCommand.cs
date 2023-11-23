using MediatR;

namespace Laul.Application.Services.LikeDislikes.Commands.DeleteLikeDislike
{
    public class DeleteLikeDislikeCommand : IRequest<Unit>
    {
        public string ArtistName { get; set; }
        public long SongId { get; set; }
    }
}
