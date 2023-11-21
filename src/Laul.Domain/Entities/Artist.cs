using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<ListeningStat> ListeningStats { get; set; }
        public virtual ICollection<LikeDislike> LikeDislikes { get; set; }
    }
}
