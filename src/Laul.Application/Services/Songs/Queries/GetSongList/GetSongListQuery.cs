using MediatR;

namespace Laul.Application.Services.Songs.Queries.GetSongList
{
    public class GetSongListQuery : IRequest<SongListVm>
    {
    }
}
