using MediatR;

namespace Laul.Application.Services.Playlists.Queries.GetPlaylistList
{
    public class GetPlaylistListQuery : IRequest<PlaylistListVm>
    {
        public Guid UserId { get; set; }
    }
}
