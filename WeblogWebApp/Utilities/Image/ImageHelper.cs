namespace WeblogWebApp.Utilities.Image
{
    public static class ImageHelper
    {
        
        public static bool RemoveOldImage(string filePath)
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", filePath);
            try
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static bool AddImage(IFormFile file, string filePath)
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var fullPath = directoryPath + filePath;
            using var stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);
     
            return true;

        }

    }
}