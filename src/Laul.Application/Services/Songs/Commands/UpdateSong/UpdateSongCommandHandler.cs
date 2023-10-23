using Laul.Application.Common.Exeption;
using Laul.Application.Interfaces.BlobStorage;
using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.Songs.Commands.UpdateSong
{
    public class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateSongCommand command, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfWork.Song.FindAsync(e => e.Id == command.Id, cancellationToken)).FirstOrDefault();

            if (entity == null || entity.Id != command.Id)
            {
                throw new NotFoundExeption(nameof(Song), command.Id);
            }

            string photoToken = 

            entity.Title = command.Title;
            entity.Genre = command.Genre;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
