using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.ListeningStats.Command.CreateListeningStat
{
    public class CreateListeningStatCommandHanlder : IRequestHandler<CreateListeningStatCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateListeningStatCommandHanlder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateListeningStatCommand command, CancellationToken cancellationToken)
        {
            var artist = (await _unitOfWork.Artist.FindAsyncNoTracking(a => a.Name == command.ArtistName)).FirstOrDefault();

            var listeningStat = new ListeningStat()
            {
                ArtistId = artist.Id,
                SongId = command.SongId,
                ListeningDate = DateTime.UtcNow,
            };

            await _unitOfWork.ListeningStats.AddAsync(listeningStat,cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return listeningStat.Id;
        }
    }
}
