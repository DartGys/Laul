using MediatR;

namespace Laul.Application.Services.Playlists.Commands.RemovePlaylistSong
{
    public class RemovePlaylistSongCommand : IRequest<Unit>
    {
        public long SongId { get; set; }
        public long PlaylistId { get; set; }
        public Guid UserId { get; set; }
    }
}
