namespace Simaira.BlobStorage.Syncing.Internal
{
    using System.IO;

    public interface IDirectory
    {
        bool Exists(string path);

        DirectoryInfo CreateDirectory(string path);
    }
}
