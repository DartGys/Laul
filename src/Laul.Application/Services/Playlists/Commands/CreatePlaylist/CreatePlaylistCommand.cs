using MediatR;

namespace Laul.Application.Services.Playlists.Commands.CreatePlaylist
{
    public class CreatePlaylistCommand : IRequest<ulong>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
