namespace Simaira.BlobStorage.Syncing.BlobStorage
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Simaira.BlobStorage.Syncing.Models;

    public interface IBlobFileRepository
    {
        Task<IEnumerable<BlobFile>> GetFileNameListFromBlobStorageAsyc();

        Task<string> SaveByetsOnBlobStorageAsync(string fileName, byte[] contents);

        Task<BlobFile> DownloadFileToByteArrayAsync(string fileName);
    }
}
