using MediatR;

namespace Laul.Application.Services.PlaylistSongs.Commands.AddPlaylistSong
{
    public class AddPlaylistSongCommand : IRequest<long>
    {
        public long SongId { get; set; }
        public long PlaylistId { get; set; }
    }
}
