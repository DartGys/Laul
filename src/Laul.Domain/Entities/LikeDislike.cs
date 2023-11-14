using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class LikeDislike
    {
        public DateTime ActionDate { get; set; }
        public bool IsLike { get; set; }
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; }
        public long SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
