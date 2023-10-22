using Laul.Application.Interfaces.Persistance;
using MediatR;
using AutoMapper;
using System;
using Laul.Application.Common.Exeption;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Songs.Queries.GetSongDetails
{
    public class GetSongDetailsQueryHandler : IRequestHandler<GetSongDetailsQuery, SongDetailsVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSongDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SongDetailsVm> Handle(GetSongDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfWork.Song.FindAsync(e => e.Id == request.Id, cancellationToken)).FirstOrDefault();

            if (entity == null || entity.ArtistId != request.ArtistId)
            {
                throw new NotFoundExeption(nameof(Song), entity.Id);
            }

            return _mapper.Map<SongDetailsVm>(entity);
        }
    }
}
