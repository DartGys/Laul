﻿using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Playlists.Queries.GetPlaylistDetails
{
    public class PlaylistDetailsVm : IMapWith<Playlist>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<SongDto> Songs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Playlist, PlaylistDetailsVm>();
        }
    }
}
