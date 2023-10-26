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
        private readonly IBlobStorageContext _blobStorageContext;

        public UpdateSongCommandHandler(IUnitOfWork unitOfWork, IBlobStorageContext blobStorageContext)
        {
            _unitOfWork = unitOfWork;
            _blobStorageContext = blobStorageContext;
        }

        public async Task<Unit> Handle(UpdateSongCommand command, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfWork.Song.FindAsync(e => e.Id == command.Id, cancellationToken)).FirstOrDefault();

            if (entity == null || entity.Id != command.Id)
            {
                throw new NotFoundExeption(nameof(Song), command.Id);
            }

            await _blobStorageContext.DeleteAsync.DeleteFileAsync(entity.Photo);

            entity.Title = command.Title;

            entity.Photo = await _blobStorageContext.UploadAsync.UploadFileAsync(command.Photo, entity.Title);

            entity.Genre = command.Genre;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
