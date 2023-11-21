
namespace Laul.Application.Services.Albums.Queries.GetAlbumListByArtist
{
    public class AlbumListVm
    {
        public IList<AlbumLookupDto> Albums { get; set; }
        public Guid ArtistId { get; set; }
    }
}
