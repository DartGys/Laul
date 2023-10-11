using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class ListeningStat
    {
        public int Id { get; set; }
        public DateTime ListeningDate { get; set; }
        public string UserId { get; set; }
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
