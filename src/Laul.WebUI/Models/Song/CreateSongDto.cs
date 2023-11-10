namespace Laul.WebUI.Models.Song
{
    public class CreateSongDto
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Song { get; set; }
        public string Genre { get; set; }
    }
}
