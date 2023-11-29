
namespace Laul.WebUI.Models.Artist
{
    public class ArtistUpdateOutputDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
    }
}
