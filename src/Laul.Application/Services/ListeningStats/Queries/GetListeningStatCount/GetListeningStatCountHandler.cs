using Laul.Application.Interfaces.Persistance;
using MediatR;

namespace Laul.Application.Services.ListeningStats.Queries.GetListeningStatCount
{
    public class GetListeningStatCountHandler : IRequestHandler<GetListeningStatCountQuery, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListeningStatCountHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(GetListeningStatCountQuery request, CancellationToken cancellationToken)
        {
            var songs = (await _unitOfWork.Song.FindAsyncNoTracking(s => s.ArtistId == request.ArtistId, cancellationToken)).ToList();

            long count = 0;

            foreach (var song in songs)
                count += (await _unitOfWork.ListeningStats.FindAsyncNoTracking(l => l.SongId == song.Id, cancellationToken)).Count();

            return count;
        }
    }
}
