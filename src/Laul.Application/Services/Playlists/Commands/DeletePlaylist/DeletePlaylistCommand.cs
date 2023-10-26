using MediatR;
namespace Laul.Application.Services.Playlists.Commands.DeletePlaylist
{
    public class DeletePlaylistCommand : IRequest<Unit>
    {
        public ulong Id { get; set; }
    }
}
