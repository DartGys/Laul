
namespace Laul.WebUI.Common.Inspector
{
    public static class Inspector
    {
        public static bool IsImage(IFormFile file)
        {
            if (file == null)
            {
                return false;
            }

            try
            {
                using (var image = Image.Load(file.OpenReadStream()))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsAudio(IFormFile file)
        {
            if (file == null)
            {
                return false;
            }

            try
            {
                file.ContentType.Contains("audio");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
