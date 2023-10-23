using Laul.Application.Interfaces;
using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace Laul.Application.Services.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageUpload _blobStorageUpload;
        public CreateAlbumCommandHandler(IUnitOfWork unitOfWork, IBlobStorageUpload blobStorageUpload)
        {
            _unitOfWork = unitOfWork;
            _blobStorageUpload = blobStorageUpload;
        }
        public async Task<int> Handle(CreateAlbumCommand command, CancellationToken cancellationToken)
        {
            string imageTokem = await _blobStorageUpload.UploadFileAsync(command.Image, command.Title);
            var album = new Album()
            {
                Title = command.Title,
                Image = imageTokem,
                PublishDate = command.PublishDate,
                Genre = command.Genre,
                ArtistId = command.ArtistId,
            };

            await _unitOfWork.Album.AddAsync(album);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return album.Id;
        }
    }
}
