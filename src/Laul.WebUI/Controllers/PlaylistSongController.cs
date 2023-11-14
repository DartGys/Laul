using Microsoft.AspNetCore.Mvc;

namespace Laul.WebUI.Controllers
{
    public class PlaylistSongController : Controller
    {
        public async Task<IActionResult> AddSongToPlaylist(long songId, long playlistId)
        {
            
            return View();
        }
    }
}
