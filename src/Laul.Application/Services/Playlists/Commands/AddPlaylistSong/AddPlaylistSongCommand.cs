using MediatR;

namespace Laul.Application.Services.Playlists.Commands.AddPlaylistSong
{
    public class AddPlaylistSongCommand : IRequest<int>
    {
        public Guid UserId { get; set; }
        public int PlaylistId { get; set; }
    }
}
