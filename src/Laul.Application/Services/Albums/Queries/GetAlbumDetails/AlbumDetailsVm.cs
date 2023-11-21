using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Albums.Queries.GetAlbumDetails
{
    public class AlbumDetailsVm : IMapWith<Album>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public Guid ArtistId { get; set; }
        public string ArtistName { get; set; }
        public IList<AlbumSongListDto> Songs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, AlbumDetailsVm>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist != null ? src.Artist.Name : null));
        }
    }
}
