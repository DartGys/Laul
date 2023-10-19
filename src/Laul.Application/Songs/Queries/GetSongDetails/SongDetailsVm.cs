using System;
using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Songs.Queries.GetSongDetails
{
    public class SongDetailsVm : IMapWith<Song>
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, SongDetailsVm>();
        }
    }
}
