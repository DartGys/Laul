using System;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.Persistance;

namespace Laul.Application.Services.Songs.Commands.CreateSong
{
    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {
            var song = new Song()
            {
                ArtistId = request.ArtistId,
                Title = request.Title,
                Duration = request.Duration,
                Genre = request.Genre,
                AlbumId = request.AlbumId,
            };

            await _unitOfWork.Song.AddAsync(song);
            await _unitOfWork.SaveChangeAsync();

            return song.ArtistId;
        }
    }
}
