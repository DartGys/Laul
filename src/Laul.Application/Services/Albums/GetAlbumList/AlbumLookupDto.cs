using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Albums.GetAlbumList
{
    public class AlbumLookupDto : IMapWith<Album>
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int Year { get; set; }
        public string ArtistName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, AlbumLookupDto>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.PublishDate.Year))
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name));
        }
    }
}
