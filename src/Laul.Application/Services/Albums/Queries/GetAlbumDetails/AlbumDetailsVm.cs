using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Albums.Queries.GetAlbumDetails
{
    public class AlbumDetailsVm : IMapWith<Album>
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string ArtistName { get; set; }
        public IEnumerable<AlbumSongListDto> Songs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, AlbumDetailsVm>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.PublishDate.Year))
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name));
        }
    }
}
