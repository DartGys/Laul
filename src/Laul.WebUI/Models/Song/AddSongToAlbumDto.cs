namespace Laul.WebUI.Models.Song
{
    public class AddSongToAlbumDto
    {
        public List<long> SongsId { get; set; }
        public long AlbumId { get; set; }
    }
}
