namespace Simaira.BlobStorage.Syncing.Application
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Simaira.BlobStorage.Syncing.BlobStorage;
    using Simaira.BlobStorage.Syncing.FileHandler;
    using Simaira.BlobStorage.Syncing.Internal;

    public class BlobStorageSyncManager : IBlobStorageSyncManager
    {
        private readonly ILogger<BlobStorageSyncManager> _logger;
        private readonly IFileHandle _fileHandler;
        private readonly IBlobFileRepository _blobFileRepository;
        private readonly IDirectory _directory;
        public BlobStorageSyncManager(ILogger<BlobStorageSyncManager> logger, IFileHandle fileHandler, IBlobFileRepository blobFileRepository, IDirectory directory)
        {
            _logger = logger;
            _fileHandler = fileHandler;
            _blobFileRepository = blobFileRepository;
            _directory = directory;
        }
        public async Task<bool> SyncStorage(string localFileStorage)
        {
            try
            {
                if (!_directory.Exists(localFileStorage))
                {
                    _directory.CreateDirectory(localFileStorage);
                }
                _logger.LogInformation($"Start Syncing from Blob Storage");

                var files = await _blobFileRepository.GetFileNameListFromBlobStorageAsyc().ConfigureAwait(false);

                if (files != null && files.ToList().Count > 0)
                {
                    _logger.LogInformation($"Total private keys file number : '{files.ToList().Count}'");
                    int count = 0;

                    foreach (var file in files)
                    {
                        _logger.LogInformation($"Start processing file : '{file.Name}'");
                        var responseFile = await _blobFileRepository.DownloadFileToByteArrayAsync(file.Name).ConfigureAwait(false);
                        if (!_fileHandler.Exists($"{localFileStorage}/{file.Name}"))
                        {
                            _fileHandler.Save(localFileStorage, responseFile);
                            count++;
                        }
                        else
                        {
                            _logger.LogInformation($"'{file.Name}' is already exist on local storage");
                        }
                    }

                    _logger.LogInformation($"Total processed file number : '{count}'");
                }
                else
                {
                    _logger.LogInformation($"No file exist to sync on Blob Storage");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to synced files from blob storage.");
                throw;
            }

        }
    }
}
