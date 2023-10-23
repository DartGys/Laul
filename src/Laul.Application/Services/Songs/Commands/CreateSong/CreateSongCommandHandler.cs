using System;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.Persistance;
using Laul.Application.Interfaces.BlobStorage;

namespace Laul.Application.Services.Songs.Commands.CreateSong
{
    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageContext _blobStorageContext;

        public CreateSongCommandHandler(IUnitOfWork unitOfWork, IBlobStorageContext blobStorageUpload)
        {
            _unitOfWork = unitOfWork;
            _blobStorageContext = blobStorageUpload;
        }

        public async Task<int> Handle(CreateSongCommand command, CancellationToken cancellationToken)
        {
            string photoToken = await _blobStorageContext.UploadAsync.UploadFileAsync(command.Photo, command.Title);
            string storageToken = await _blobStorageContext.UploadAsync.UploadFileAsync(command.Storage, command.Title);

            var song = new Song()
            {
                ArtistId = command.ArtistId,
                Title = command.Title,
                Duration = command.Duration,
                PublishDate = command.PublishDate,
                Photo = photoToken,
                Storage = storageToken,
                Genre = command.Genre,
                AlbumId = command.AlbumId,
            };

            await _unitOfWork.Song.AddAsync(song, cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return song.Id;
        }
    }
}
