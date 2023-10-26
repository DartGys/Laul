using Laul.Application.Services.Albums.Commands.CreateAlbum;
using Laul.Application.Services.Albums.GetAlbumList;
using Laul.Application.Services.Songs.Commands.CreateSong;
using Laul.Application.Services.Songs.Queries.GetSongList;
using Laul.WebUI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            string photoPath = @"C:\Users\boda2\Downloads\274px-Убили_негра.jpg";
            var fileProvider = new PhysicalFileProvider(Path.GetDirectoryName(photoPath));

            // Отримуємо інформацію про файл
            var fileInfo = fileProvider.GetFileInfo(Path.GetFileName(photoPath));

            // Створюємо об'єкт IFormFile з інформацією про файл
            var photoFile = new FormFile(fileInfo.CreateReadStream(), 0, fileInfo.Length, null, fileInfo.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpg" // Тип контенту може бути змінений відповідно до реального типу файлу
            };

            var command = new CreateAlbumCommand
            {
                ArtistId = new Guid("D53201B9-824B-4EA4-8C66-4FA2BA14A3F9"),
                PublishDate = DateTime.Now,
                Genre = "Jazz2",
                Image = photoFile,
                Title = "Title2",
            };
            var result = await _mediator.Send(command);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}