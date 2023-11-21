using MediatR;

namespace Laul.Application.Services.Playlists.Commands.CreatePlaylist
{
    public class CreatePlaylistCommand : IRequest<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    }
}
