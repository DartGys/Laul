using MediatR;
namespace Laul.Application.Services.LikeDislikes.Commands.CreateLikeDislike
{
    public class CreateLikeDislikeCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public ulong SongId { get; set; }
        public bool IsLike { get; set; }
    }
}
