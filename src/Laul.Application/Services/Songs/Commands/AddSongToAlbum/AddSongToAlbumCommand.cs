using MediatR;

namespace Laul.Application.Services.Songs.Commands.AddSongToAlbum
{
    public class AddSongToAlbumCommand : IRequest<Unit>
    {
        public long SongId { get; set; }
        public long AlbumId { get; set; }
    }
}
