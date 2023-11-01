using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Artists.Queries.GetArtistDetails
{
    public class ArtistDetilsVm : IMapWith<Artist>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public IList<ArtistSongListDto> Songs { get; set; }
        public IList<ArtistAlbumListDto> Albums { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Artist, ArtistDetilsVm>();
        }
    }
}
