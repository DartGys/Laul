using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Application.Services.Songs.Queries.GetSongList
{
    public class SongListVm
    {
        public IList<SongLookupDto> Songs { get; set; }
    }
}
