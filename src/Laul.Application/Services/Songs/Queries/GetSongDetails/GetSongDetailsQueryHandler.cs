﻿using Laul.Application.Interfaces.Persistance;
using MediatR;
using AutoMapper;
using Laul.Application.Common.Exeption;
using Laul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using System.Windows.Markup;

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
            var entity = await _unitOfWork.Song.GetById(request.Id, cancellationToken);

            if (entity == null || entity.ArtistId != request.ArtistId)
            {
                throw new NotFoundExeption(nameof(Song), entity.Id);
            }

            var album = await _unitOfWork.Album.GetById(entity.AlbumId, cancellationToken);
            var artist = await _unitOfWork.Artist.GetById(entity.ArtistId,cancellationToken);
            var listeningCount = (await _unitOfWork.ListeningStats.FindAsyncNoTracking(l => l.SongId == request.Id, cancellationToken)).Count();
            var like = (await _unitOfWork.LikeDislike.FindAsyncNoTracking(l => l.SongId == request.Id && l.IsLike == true)).Count();
            var dislike = (await _unitOfWork.LikeDislike.FindAsyncNoTracking(l => l.SongId == request.Id && l.IsLike == false)).Count();

            var song = await (await _unitOfWork.Song.FindAsync(s => s.Id == request.Id, cancellationToken))
                .AsQueryable()
                .Include(album.Title)
                .Include(artist.Name)
                .ProjectTo<SongDetailsVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            song.listeningCount = (ulong)listeningCount;
            song.likeCount = (ulong)like;
            song.dislikeCount = (ulong)dislike;

            return _mapper.Map<SongDetailsVm>(song);
        }
    }
}
