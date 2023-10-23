using System;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.Persistance;
using Laul.Application.Interfaces;

namespace Laul.Application.Services.Songs.Commands.CreateSong
{
    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageUpload _blobStorageUpdload;

        public CreateSongCommandHandler(IUnitOfWork unitOfWork, IBlobStorageUpload blobStorageUpload)
        {
            _unitOfWork = unitOfWork;
            _blobStorageUpdload = blobStorageUpload;
        }

        public async Task<int> Handle(CreateSongCommand command, CancellationToken cancellationToken)
        {
            string photoToken = await _blobStorageUpdload.UploadFileAsync(command.Photo, command.Title);
            string storageToken = await _blobStorageUpdload.UploadFileAsync(command.Storage, command.Title);

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

            await _unitOfWork.Song.AddAsync(song);
            await _unitOfWork.SaveChangeAsync();

            return song.Id;
        }
    }
}
