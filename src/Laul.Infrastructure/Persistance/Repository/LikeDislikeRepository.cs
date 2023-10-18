using Laul.Application.Interfaces.Persistance.Repository;
using Laul.Domain.Entities;
using Laul.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Infrastructure.Persistance.Repository
{
    public class LikeDislikeRepository : GenericRepository<LikeDislike>, ILikeDislikeRepository
    {
        public LikeDislikeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
