using MediatR;

namespace Laul.Application.Services.ListeningStats.Queries.GetListeningStatCount
{
    public class GetListeningStatCountQuery : IRequest<long>
    {
        public Guid ArtistId { get; set; }
    }
}
