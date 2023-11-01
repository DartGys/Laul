using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class ListeningStat
    {
        public long Id { get; set; }
        public DateTime ListeningDate { get; set; }
        public Guid UserId { get; set; }
        public long SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
