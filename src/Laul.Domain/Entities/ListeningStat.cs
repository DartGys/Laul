using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class ListeningStat
    {
        public ulong Id { get; set; }
        public DateTime ListeningDate { get; set; }
        public Guid UserId { get; set; }
        public ulong SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
