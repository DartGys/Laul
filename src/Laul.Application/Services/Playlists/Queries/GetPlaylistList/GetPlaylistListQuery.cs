using MediatR;

namespace Laul.Application.Services.Playlists.Queries.GetPlaylistList
{
    public class GetPlaylistListQuery : IRequest<PlaylistListVm>
    {
        public string UserName { get; set; }
    }
}
