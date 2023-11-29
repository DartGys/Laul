using MediatR;

namespace Laul.Application.Services.Songs.Commands.DeleteSongFromAlbum
{
    public class DeleteSongFromAlbumCommand : IRequest<Unit>
    {
        public long SongId {  get; set; }
    }
}
