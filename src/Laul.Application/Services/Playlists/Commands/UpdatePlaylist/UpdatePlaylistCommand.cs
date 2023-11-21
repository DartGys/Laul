using MediatR;

namespace Laul.Application.Services.Playlists.Commands.UpdatePlaylist
{
    public class UpdatePlaylistCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
