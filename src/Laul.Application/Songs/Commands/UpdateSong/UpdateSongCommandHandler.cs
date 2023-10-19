using Laul.Application.Common.Exeption;
using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Songs.Commands.UpdateSong
{
    public class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateSongCommand request, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfWork.Song.FindAsync(e => e.Id == request.Id, cancellationToken)).FirstOrDefault();

            if(entity == null || entity.Id != request.Id)
            {
                throw new NotFoundExeption(nameof(Song), request.Id);
            }

            entity.Title = request.Title;
            entity.Genre = request.Genre;   

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
