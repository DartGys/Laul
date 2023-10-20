using System;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.Persistance;

namespace Laul.Application.Services.Songs.Commands.CreateSong
{
    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateSongCommand command, CancellationToken cancellationToken)
        {
            var song = new Song()
            {
                ArtistId = command.ArtistId,
                Title = command.Title,
                Duration = command.Duration,
                Genre = command.Genre,
                AlbumId = command.AlbumId,
            };

            await _unitOfWork.Song.AddAsync(song);
            await _unitOfWork.SaveChangeAsync();

            return song.Id;
        }
    }
}
