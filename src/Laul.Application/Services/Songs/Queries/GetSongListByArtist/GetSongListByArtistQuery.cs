using Laul.Application.Services.Songs.Queries.GetSongListByArtist;
using MediatR;

namespace Laul.Application.Services.Songs.Queries.GetSongByArtist
{
    public class GetSongListByArtistQuery : IRequest<SongListByArtistVm>
    {
        public string UserName { get; set; }
    }
}
