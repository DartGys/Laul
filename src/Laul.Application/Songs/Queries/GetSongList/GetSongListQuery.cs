using MediatR;

namespace Laul.Application.Songs.Queries.GetSongList
{
    public class GetSongListQuery : IRequest<SongListVm>
    {
    }
}
