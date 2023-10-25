using AutoMapper;
using AutoMapper.QueryableExtensions;
using Laul.Application.Interfaces.Persistance;
using MediatR;
using System.Net.Http.Headers;

namespace Laul.Application.Services.Playlists.Queries.GetPlaylistList
{
    public class GetPlaylistListQueryHandler : IRequestHandler<GetPlaylistListQuery, PlaylistListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlaylistListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PlaylistListVm> Handle(GetPlaylistListQuery request, CancellationToken cancellationToken)
        {
            var playlistList = (await _unitOfWork.Playlist.FindAsync(p => p.UserId == request.UserId))
                .AsQueryable()
                .ProjectTo<PlaylistLookupDto>(_mapper.ConfigurationProvider)
                .ToList();

            return new PlaylistListVm { Playlists = playlistList };
        }
    }
}
