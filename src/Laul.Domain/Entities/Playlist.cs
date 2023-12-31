﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class Playlist
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
