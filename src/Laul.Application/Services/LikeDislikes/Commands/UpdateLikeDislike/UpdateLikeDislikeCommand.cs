using MediatR;

namespace Laul.Application.Services.LikeDislikes.Commands.UpdateLikeDislike
{
    public class UpdateLikeDislikeCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public ulong SongId { get; set; }
    }
}
