using MediatR;

namespace Laul.Application.Services.LikeDislikes.Queries.GetLikeDislike
{
    public class GetLikeDislikeQuery : IRequest<LikeDislikeDto>
    {
        public string ArtistName { get; set; }
        public long SongId { get; set; }
    }
}
