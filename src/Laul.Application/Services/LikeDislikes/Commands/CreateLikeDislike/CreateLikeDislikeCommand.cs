using MediatR;
namespace Laul.Application.Services.LikeDislikes.Commands.CreateLikeDislike
{
    public class CreateLikeDislikeCommand : IRequest<int>
    {
        public Guid UserId { get; set; }
        public int SongId { get; set; }
        public bool IsLike { get; set; }
    }
}
