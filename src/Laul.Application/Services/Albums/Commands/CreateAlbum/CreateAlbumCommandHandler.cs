﻿using Laul.Application.Interfaces.BlobStorage;
using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageContext _blobStorageContext;
        public CreateAlbumCommandHandler(IUnitOfWork unitOfWork, IBlobStorageContext blobStorageUpload)
        {
            _unitOfWork = unitOfWork;
            _blobStorageContext = blobStorageUpload;
        }
        public async Task<int> Handle(CreateAlbumCommand command, CancellationToken cancellationToken)
        {
            string imageTokem = await _blobStorageContext.UploadAsync.UploadFileAsync(command.Image, command.Title);
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