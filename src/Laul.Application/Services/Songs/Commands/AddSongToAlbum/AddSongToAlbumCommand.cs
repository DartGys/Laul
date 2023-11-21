using MediatR;

namespace Laul.Application.Services.Songs.Commands.AddSongToAlbum
{
    public class AddSongToAlbumCommand : IRequest<Unit>
    {
        public List<long> SongsId { get; set; }
        public long AlbumId { get; set; }
    }
}
