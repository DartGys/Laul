using Laul.Application.Services.Songs.Queries.GetSongList;
using Laul.WebUI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace Laul.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var request = new GetSongListQuery()
            {
                Count = 50
            };
            var models = await _mediator.Send(request);


            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}