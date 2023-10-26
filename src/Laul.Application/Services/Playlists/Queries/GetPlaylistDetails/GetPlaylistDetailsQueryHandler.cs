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


            var playlist = (await _unitOfWork.Playlist.FindAsyncNoTracking(a => a.Id == request.Id, cancellationToken))
                .AsQueryable()
                .ProjectTo<PlaylistDetailsVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            var songs = (await _unitOfWork.Song.FindAsyncNoTracking(s => s.AlbumId == request.Id, cancellationToken, a => a.Artist, a => a.Album))
                .AsQueryable()
                .ProjectTo<PlaylistSongListDto>(_mapper.ConfigurationProvider)
                .ToList();

            var playlistDetailsVm = _mapper.Map<PlaylistDetailsVm>(playlist);
            playlistDetailsVm.Songs = _mapper.Map<IList<PlaylistSongListDto>>(songs);

            return playlistDetailsVm;
        }
    }
}
