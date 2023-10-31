using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Artists.Queries.GetArtistDetails
{
    public class ArtistAlbumListDto : IMapWith<Album>
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, ArtistAlbumListDto>();
        }
    }
}
