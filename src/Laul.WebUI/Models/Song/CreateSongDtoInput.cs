namespace Laul.WebUI.Models.Song
{
    public class CreateSongDtoInput
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Storage { get; set; }
        public string Genre { get; set; }
    }
}
