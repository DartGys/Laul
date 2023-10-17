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
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
