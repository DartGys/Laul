namespace Laul.WebUI.Models.LikeDislike
{
    public class AddLikeDislikeDto
    {
        public string ArtistName { get; set; }
        public long SongId { get; set; }
        public bool IsLike { get; set; }
    }
}
