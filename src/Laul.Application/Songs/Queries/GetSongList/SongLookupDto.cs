using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;
using System;

namespace Laul.Application.Songs.Queries.GetSongList
{
    public class SongLookupDto : IMapWith<Song>
    {
        public string Title { get; set; }
        public int Duration { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, SongLookupDto>();
        }
    }
}
