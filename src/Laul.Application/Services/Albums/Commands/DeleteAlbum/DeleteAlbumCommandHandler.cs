using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.BlobStorage;

namespace Laul.Application.Services.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IBlobStorageContext _blobStorageContext;
        public DeleteAlbumCommandHandler(IUnitOfWork unitOfwork, IBlobStorageContext blobStorageContext)
        {
            _unitOfwork = unitOfwork;
            _blobStorageContext = blobStorageContext;
        }
        
        public async Task<Unit> Handle(DeleteAlbumCommand command, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfwork.Album.FindAsync(e => e.Id == command.Id, cancellationToken)).FirstOrDefault();

            if (entity == null || command.ArtistId != entity.ArtistId)
            {
                throw new NotFoundExeption(nameof(Album), entity.Id);
            }

            await _blobStorageContext.DeleteAsync.DeleteFileAsync(entity.Image);

            _unitOfwork.Album.Remove(entity);
            await _unitOfwork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
