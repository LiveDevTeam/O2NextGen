namespace O2NextGen.MediaBasket.Api.Helpers
{
    public static class FileExt
    {
        public static string GetFileExtension(this string fileName)
        {
            return System.IO.Path.GetExtension(fileName).ToLower();
        }
    }
}