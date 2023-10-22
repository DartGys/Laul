﻿using Laul.Application.Common.Exeption;
using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Application.Services.Songs.Commands.DeleteSong
{
    public class DeleteSongCommandHandler
        : IRequestHandler<DeleteSongCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteSongCommand command, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfWork.Song.FindAsync(e => e.Id == command.Id, cancellationToken)).FirstOrDefault();

            if (entity == null || entity.ArtistId != command.ArtistId)
            {
                throw new NotFoundExeption(nameof(Song), entity.Id);
            }

            _unitOfWork.Song.Remove(entity);
            await _unitOfWork.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
