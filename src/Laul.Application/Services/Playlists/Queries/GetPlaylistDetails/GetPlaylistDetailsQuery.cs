using MediatR;

namespace Laul.Application.Services.Playlists.Queries.GetPlaylistDetails
{
    public class GetPlaylistDetailsQuery : IRequest<PlaylistDetailsVm>
    {
        public long Id { get; set; }
    }
}
