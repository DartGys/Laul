using MediatR;


namespace Laul.Application.Services.Albums.Queries.GetAlbumDetails
{
    public class GetAlbumDetailsQuery : IRequest<AlbumDetailsVm>
    {
        public int Id { get; set; }
        public Guid ArtistId { get; set; }
    }
}
