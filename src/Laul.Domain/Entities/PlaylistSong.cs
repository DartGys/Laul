using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class PlaylistSong
    {
        public long PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public long SongId { get; set; }
        public Song Song { get; set; }
    }
}
