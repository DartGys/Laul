using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.ListeningStats.Command.CreateListeningStat
{
    public class CreateListeningStatCommandHanlder : IRequestHandler<CreateListeningStatCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateListeningStatCommandHanlder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateListeningStatCommand command, CancellationToken cancellationToken)
        {
            var listeningStat = new ListeningStat()
            {
                UserId = command.UserId,
                SongId = command.SongId,
                ListeningDate = command.ListeningDate,
            };

            await _unitOfWork.ListeningStats.AddAsync(listeningStat,cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return listeningStat.Id;
        }
    }
}
