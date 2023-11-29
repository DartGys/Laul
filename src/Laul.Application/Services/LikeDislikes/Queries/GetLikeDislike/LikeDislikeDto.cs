using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.LikeDislikes.Queries.GetLikeDislike
{
    public class LikeDislikeDto : IMapWith<LikeDislike>
    {
        public bool IsLike { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LikeDislike, LikeDislikeDto>();
        }
    }
}
