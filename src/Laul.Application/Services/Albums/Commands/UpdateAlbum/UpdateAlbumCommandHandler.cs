using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAlbumCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAlbumCommand command, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfWork.Album.FindAsync(e => e.Id == command.Id, cancellationToken)).FirstOrDefault();

            if (entity == null || entity.Id != command.Id)
            {
                throw new NotFoundExeption(nameof(Album), entity.Id);
            }

            entity.Title = command.Title;
            entity.Image = command.Image;
            entity.Genre = command.Genre;

            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
