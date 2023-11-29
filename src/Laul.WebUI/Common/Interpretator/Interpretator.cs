using System.Net.Http;

namespace Laul.WebUI.Common.Interpretator
{
    public static class Interpretator
    {
        public static async Task<IFormFile> GetImageAsFormFileAsync(string imageUrl)
        {
            using (var httpClient = new HttpClient())
            {
                var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                // Отримати ім'я файлу з посилання
                var fileName = Path.GetFileName(imageUrl);

                // Створити новий екземпляр IFormFile
                var formFile = new FormFile(new MemoryStream(imageBytes), 0, imageBytes.Length, null, fileName)
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "image/jpeg"
                };

                return formFile;
            }
        }
    }
}
