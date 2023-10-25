using MediatR;

namespace Laul.Application.Services.Playlists.Queries.GetPlaylistList
{
    public class GetPlaylistListQuery : IRequest<PlaylistListVm>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
    }
}
