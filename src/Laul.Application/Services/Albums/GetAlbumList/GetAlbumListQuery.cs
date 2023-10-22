using MediatR;

namespace Laul.Application.Services.Albums.GetAlbumList
{
    public class GetAlbumListQuery : IRequest<AlbumListVm>
    {
        public Guid ArtistId { get; set; }
    }
}
