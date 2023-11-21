namespace Laul.WebUI.Models.Album
{
    public class CreateAlbumInputDto
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
