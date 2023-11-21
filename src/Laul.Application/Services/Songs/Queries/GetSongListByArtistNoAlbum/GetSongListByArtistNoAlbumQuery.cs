using MediatR;

namespace Laul.Application.Services.Songs.Queries.GetSongListByArtistNoAlbum
{
    public class GetSongListByArtistNoAlbumQuery : IRequest<SongListByArtistNoAlbumVm>
    {
        public string UserName { get; set; }
    }
}
