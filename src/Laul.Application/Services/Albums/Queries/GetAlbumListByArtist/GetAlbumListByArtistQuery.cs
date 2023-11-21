using MediatR;
namespace Laul.Application.Services.Albums.Queries.GetAlbumListByArtist
{
    public class GetAlbumListByArtistQuery : IRequest<AlbumListVm>
    {
        public string UserName {  get; set; }
    }
}
