using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.BlobStorage;

namespace Laul.Application.Services.Artists.Commands.DeleteArtist
{
    public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageContext _blobStorageContext;

        public DeleteArtistCommandHandler(IUnitOfWork unitOfWork ,IBlobStorageContext blobStorageContext)
        {
            _unitOfWork = unitOfWork;
            _blobStorageContext = blobStorageContext;
        }

        public async Task<Unit> Handle(DeleteArtistCommand command, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Artist.GetById(command.Id, cancellationToken);

            if (entity == null || command.Id != entity.Id)
            {
                throw new NotFoundExeption(nameof(Artist), entity.Id);
            }

            await _blobStorageContext.DeleteAsync.DeleteFileAsync(entity.Photo);

            _unitOfWork.Artist.Remove(entity);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
