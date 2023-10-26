using MediatR;

namespace Laul.Application.Services.Albums.Queries.GetAlbumList
{
    public class GetAlbumListQuery : IRequest<AlbumListVm>
    {
        public Guid ArtistId { get; set; }
    }
}
