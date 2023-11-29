using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Songs.Queries.GetSongListByArtist
{
    public class SongLookupDto : IMapWith<Song>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Photo {  get; set; }
        public string Storage { get; set; }
        public Guid ArtistId { get; set; }
        public string ArtistName { get; set; }
        public long AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int ListeningCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, SongLookupDto>()
                .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album != null ? src.Album.Title : null))
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name))
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.LikeDislikes != null ? src.LikeDislikes.Where(l => l.IsLike == true).Count() : 0))
                .ForMember(dest => dest.DislikeCount, opt => opt.MapFrom(src => src.LikeDislikes != null ? src.LikeDislikes.Where(l => l.IsLike == false).Count() : 0))
                .ForMember(dest => dest.ListeningCount, opt => opt.MapFrom(src => src.ListeningStats != null ? src.ListeningStats.Count() : 0));
        }

    }
}
