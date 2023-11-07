using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.BlobStorage;

namespace Laul.Application.Services.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageContext _blobStorageContext;

        public UpdateArtistCommandHandler(IUnitOfWork unitOfWork ,IBlobStorageContext blobStorageContext)
        {
            _unitOfWork = unitOfWork;
            _blobStorageContext = blobStorageContext;
        }

        public async Task<Unit> Handle(UpdateArtistCommand command, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Artist.GetById(command.Id, cancellationToken);

            if (entity == null || entity.Id != command.Id)
            {
                throw new NotFoundExeption(nameof(Album), entity.Id);
            }

            await _blobStorageContext.DeleteAsync.DeleteFileAsync(entity.Photo);

            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.Photo = await _blobStorageContext.UploadAsync.UploadFileAsync(command.Photo, command.Name);

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
