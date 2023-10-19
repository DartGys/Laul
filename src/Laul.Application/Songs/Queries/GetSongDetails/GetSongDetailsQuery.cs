using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace Laul.Application.Songs.Queries.GetSongDetails
{
    public class SongDetails : IMapWith<Song>
    {
        public Guid ArtitId;
        public string Title;
        public int Duration;
        public string Genre;
    }
}
