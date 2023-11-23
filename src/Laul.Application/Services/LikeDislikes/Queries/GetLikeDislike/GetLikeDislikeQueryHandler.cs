using Laul.Application.Interfaces.Persistance;
using AutoMapper;
using MediatR;

namespace Laul.Application.Services.LikeDislikes.Queries.GetLikeDislike
{
    public class GetLikeDislikeQueryHandler : IRequestHandler<GetLikeDislikeQuery, LikeDislikeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLikeDislikeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LikeDislikeDto> Handle(GetLikeDislikeQuery request, CancellationToken cancellationToken)
        {
            var artist = (await _unitOfWork.Artist.FindAsyncNoTracking(a => a.Name == request.ArtistName, cancellationToken)).FirstOrDefault();

            var entity = (await _unitOfWork.LikeDislike.FindAsyncNoTracking(e => e.SongId == request.SongId && e.ArtistId == artist.Id, cancellationToken)).FirstOrDefault();

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<LikeDislikeDto>(entity);
        }
    }
}
