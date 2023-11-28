namespace Laul.WebUI.Models.Song
{
    public class SongQueueVm
    {
        public IList<SongQueueDto> queueList {  get; set; }
        public class SongQueueDto
        {
            public long albumId { get; set; }
            public string albumTitle { get; set; }
            public long artistId { get; set; }
            public string artistName { get; set; }
            public long id { get; set; }
            public string photo { get; set; }
            public string storage { get; set; }
            public string title { get; set; }
        }
    }
}
