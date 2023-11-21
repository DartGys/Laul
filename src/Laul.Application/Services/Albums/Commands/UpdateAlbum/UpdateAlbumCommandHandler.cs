using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.BlobStorage;

namespace Laul.Application.Services.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageContext _blobStorageContext;
        public UpdateAlbumCommandHandler(IUnitOfWork unitOfWork, IBlobStorageContext blobStorageContext)
        {
            _unitOfWork = unitOfWork;
            _blobStorageContext = blobStorageContext;
        }

        public async Task<Unit> Handle(UpdateAlbumCommand command, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfWork.Album.FindAsync(e => e.Id == command.Id, cancellationToken)).FirstOrDefault();

            if (entity == null || entity.Id != command.Id)
            {
                throw new NotFoundExeption(nameof(Album), entity.Id);
            }

            await _blobStorageContext.DeleteAsync.DeleteFileAsync(entity.Image);

            entity.Title = command.Title;
            //entity.Image = await _blobStorageContext.UploadAsync.UploadFileAsync(command.Image, command.Title);
            entity.Genre = command.Genre;

            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
