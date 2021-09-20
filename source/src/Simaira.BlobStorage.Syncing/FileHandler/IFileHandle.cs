namespace Simaira.BlobStorage.Syncing.FileHandler
{
    using Simaira.BlobStorage.Syncing.Models;

    public interface IFileHandle
    {
        bool Exists(string path);

        bool Save(string path, BlobFile file);
    }
}
