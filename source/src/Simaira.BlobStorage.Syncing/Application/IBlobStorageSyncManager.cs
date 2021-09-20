namespace Simaira.BlobStorage.Syncing.Application
{
    using System.Threading.Tasks;

    public interface IBlobStorageSyncManager
    {
        Task<bool> SyncStorage(string localFileStorage);
    }
}
