using Microsoft.AspNetCore.Mvc;

namespace Laul.WebUI.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
