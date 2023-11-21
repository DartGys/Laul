using System.ComponentModel.DataAnnotations;

namespace Laul.WebUI.Models.Album
{
    public class CreateAlbumDto
    {
        public Guid ArtistId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
