using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Albums.Queries.GetAlbumListByArtist
{
    public class AlbumLookupDto : IMapWith<Album>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, AlbumLookupDto>();
        }
    }
}
