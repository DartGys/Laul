using MediatR;


namespace Laul.Application.Services.Albums.Queries.GetAlbumDetails
{
    public class GetAlbumDetailsQuery : IRequest<AlbumDetailsVm>
    {
        public long Id { get; set; }
        public Guid ArtistId { get; set; }
    }
}
