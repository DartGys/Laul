using Laul.Application.Interfaces.EntitiesRepository;
using Laul.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Infrastructure.Data.Repository
{
    public class PlaylistSongRepository : Repository<PlaylistSong>, IPlaylistSongRepository
    {
        public PlaylistSongRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
