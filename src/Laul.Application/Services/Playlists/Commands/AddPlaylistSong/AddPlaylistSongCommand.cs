using MediatR;

namespace Laul.Application.Services.Playlists.Commands.AddPlaylistSong
{
    public class AddPlaylistSongCommand : IRequest<int>
    {
        public Guid UserId { get; set; }
        public ulong SongId { get; set; }
        public ulong PlaylistId { get; set; }
    }
}
