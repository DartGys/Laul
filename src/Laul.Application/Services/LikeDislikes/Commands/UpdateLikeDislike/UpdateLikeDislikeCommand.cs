using MediatR;

namespace Laul.Application.Services.LikeDislikes.Commands.UpdateLikeDislike
{
    public class UpdateLikeDislikeCommand : IRequest<Unit>
    {
        public string ArtistName { get; set; }
        public long SongId { get; set; }
    }
}
