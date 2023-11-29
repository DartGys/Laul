using System.ComponentModel.DataAnnotations;

namespace Laul.WebUI.Models.Song
{
    public class CreateSongDto
    {
        public Guid ArtistId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "PublishDate is required")]
        [Range(typeof(DateTime), "1950-01-01", "2024-01-01", ErrorMessage = "Date can be between 2000-01-01 and 2024-01-01")]
        public DateTime PublishDate { get; set; }
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = "Song is required")]
        public IFormFile Song { get; set; }
        public string Genre { get; set; }
    }
}
