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
        public int UserId { get; set; }
        public int ResourceId { get; set; }
    }
}
