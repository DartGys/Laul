using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class Song
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Storage { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public Guid ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public long AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<LikeDislike> LikeDislikes { get; set; }
        public virtual ICollection<ListeningStat> ListeningStats { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
