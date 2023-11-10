namespace Laul.WebUI.Models.Artist
{
    public class ArtistUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}
