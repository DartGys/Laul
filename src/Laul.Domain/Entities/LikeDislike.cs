using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class LikeDislike
    {
        public int Id { get; set; }
        public DateTime ActionDate { get; set; }
        public bool IsLike { get; set; }
        public Guid UserId { get; set; }
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
