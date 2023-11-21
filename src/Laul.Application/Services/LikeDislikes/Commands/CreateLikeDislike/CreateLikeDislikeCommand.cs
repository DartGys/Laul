using MediatR;
namespace Laul.Application.Services.LikeDislikes.Commands.CreateLikeDislike
{
    public class CreateLikeDislikeCommand : IRequest<Guid>
    {
        public Guid ArtistId { get; set; }
        public long SongId { get; set; }
        public bool IsLike { get; set; }
    }
}
