using MediatR;

namespace Laul.Application.Services.Playlists.Commands.RemovePlaylistSong
{
    public class RemovePlaylistSongCommand : IRequest<Unit>
    {
        public ulong SongId { get; set; }
        public ulong PlaylistId { get; set; }
        public Guid UserId { get; set; }
    }
}
