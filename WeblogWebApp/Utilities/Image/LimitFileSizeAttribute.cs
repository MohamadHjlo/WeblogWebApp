namespace WeblogWebApp.Utilities.Image
{
    public static class LimitFileSize
    {
        private static int FileSize { get; set; } = 2 * 1024 * 1024;

        public static  bool IsValid(object value)
        {
            IFormFile file = value as IFormFile;
            bool isValid = true;

            int allowedFileSize = FileSize;

            if (file != null)
            {
                var fileSize = file.Length;
                isValid = fileSize <= allowedFileSize;
            }

            return isValid;
        }

    }
}
