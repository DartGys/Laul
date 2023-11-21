using MediatR;

namespace Laul.Application.Services.PlaylistSongs.Commands.RemovePlaylistSong
{
    public class RemovePlaylistSongCommand : IRequest<Unit>
    {
        public long SongId { get; set; }
        public long PlaylistId { get; set; }
    }
}
