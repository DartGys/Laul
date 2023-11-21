using MediatR;
using AutoMapper;
using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using Laul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Laul.Application.Services.Playlists.Queries.GetPlaylistDetails
{
    public class GetPlaylistDetailsQueryHandler : IRequestHandler<GetPlaylistDetailsQuery, PlaylistDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPlaylistDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PlaylistDetailsVm> Handle(GetPlaylistDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Playlist.GetById(request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundExeption(nameof(Playlist), request.Id);
            }


            var playlist = _mapper.Map<PlaylistDetailsVm>(entity);

            var playlistSongs = await _unitOfWork.PlaylistSong.FindAsyncNoTracking(p => p.PlaylistId == request.Id, cancellationToken);

            var songs = new List<SongDto>();

            foreach (var playlistsong in playlistSongs)
            {
                var song = (await _unitOfWork.Song.FindAsyncNoTracking(s => s.Id == playlistsong.SongId, cancellationToken, a => a.Artist, a => a.Album))
                    .AsQueryable()
                    .ProjectTo<SongDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                songs.Add(song);
            }

            playlist.Songs = new List<SongDto>(songs);

            return playlist;
        }
    }
}
