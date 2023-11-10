using System;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.Persistance;
using Laul.Application.Interfaces.BlobStorage;

namespace Laul.Application.Services.Songs.Commands.CreateSong
{
    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageContext _blobStorageContext;

        public CreateSongCommandHandler(IUnitOfWork unitOfWork, IBlobStorageContext blobStorageUpload)
        {
            _unitOfWork = unitOfWork;
            _blobStorageContext = blobStorageUpload;
        }

        public async Task<long> Handle(CreateSongCommand command, CancellationToken cancellationToken)
        {
            string photoToken = command.Photo == null ? null :
                await _blobStorageContext.UploadAsync.UploadFileAsync(command.Photo, nameof(command.Photo), command.Title);
            string storageToken = command.Storage == null ? null :
                await _blobStorageContext.UploadAsync.UploadFileAsync(command.Storage, nameof(command.Storage), command.Title);

            var song = new Song()
            {
                ArtistId = command.ArtistId,
                Title = command.Title,
                PublishDate = command.PublishDate,
                Photo = photoToken,
                Storage = storageToken,
                Genre = command.Genre,
                AlbumId = null,
            };

            await _unitOfWork.Song.AddAsync(song, cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return song.Id;
        }
    }
}
