using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.BlobStorage;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using System.Collections;

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

            entity.Description = command.Description;
            if (command.Photo != null)
            {
                if (entity.Photo != null)
                {
                    await _blobStorageContext.DeleteAsync.DeleteFileAsync(entity.Photo);
                }
                var token = await _blobStorageContext.UploadAsync.UploadFileAsync(command.Photo, nameof(command.Photo), entity.Name);
                entity.Photo = token;
            }

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
