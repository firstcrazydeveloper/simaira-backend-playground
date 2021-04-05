namespace Simaira.BlobStorage.FileStorage
{
    using System.IO;
    using System.Text;
    public static class FileReader
    {
        public static string GetResourceContent(string resource)
        {
            using (FileStream fsSource = new FileStream(resource,
            FileMode.Open, FileAccess.Read))
            {
                using var streamReader = new StreamReader(fsSource, UTF8Encoding.UTF8, false);
                var content = streamReader.ReadToEnd();
                return content;
            }
        }

        public static FileStream GetResourceStream(string resource)
        {
            FileStream fsSource = new FileStream(resource, FileMode.Open, FileAccess.Read);
            return fsSource;

        }
    }
}
