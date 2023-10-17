using Laul.Application.Interfaces.EntitiesRepository;
using Laul.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Infrastructure.Data.Repository
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
