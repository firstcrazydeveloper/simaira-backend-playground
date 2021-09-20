namespace Simaira.BlobStorage.Syncing.BlobStorage
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Simaira.BlobStorage.Syncing.Models;

    public class BlobFileRepository : IBlobFileRepository
    {
        private readonly string _storageConnectionString;
        private readonly string _containerName;
        private readonly string _blobSasExpiryDuration;
        private readonly ILogger<BlobFileRepository> _logger;

        public BlobFileRepository(ILogger<BlobFileRepository> logger)
        {
            _logger = logger;
            _blobSasExpiryDuration = "120";
            _containerName = "tsp";
            _storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=sqlvaysju46x26sqrw;AccountKey=khrFt5Oio6ijLVDn187+j1vkX5k35zkT2Al7LtqHgd8DuxqiQD1A7E1wlQoeOCuCVtae4pFB4oiCXu/4e0vMFg==;EndpointSuffix=core.windows.net";
        }

        public async Task<BlobFile> DownloadFileToByteArrayAsync(string fileName)
        {
            try
            {
                var container = await GetBlobContainerAsync(_containerName).ConfigureAwait(false);
                CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(fileName);
                await cloudBlockBlob.FetchAttributesAsync().ConfigureAwait(false);
                long fileByteLength = cloudBlockBlob.Properties.Length;
                byte[] fileContent = new byte[fileByteLength];
                for (int i = 0; i < fileByteLength; i++)
                {
                    fileContent[i] = 0x20;
                }

                await cloudBlockBlob.DownloadToByteArrayAsync(fileContent, 0);
                return new BlobFile { Name = fileName, Contents = fileContent };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to download file : '{fileName}'.");
                throw;
            }
        }

        public async Task<IEnumerable<BlobFile>> GetFileNameListFromBlobStorageAsyc()
        {
            try
            {
                var container = await GetBlobContainerAsync(_containerName).ConfigureAwait(false);
                BlobContinuationToken continuationToken = null;
                var blobResultSegment = await container.ListBlobsSegmentedAsync(continuationToken);
                var response = blobResultSegment.Results.Cast<CloudBlockBlob>().Select(b => new BlobFile { Name = b.Name }).ToList();
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to get file name list from blob storage.");
                throw;
            }
        }

        public async Task<string> SaveByetsOnBlobStorageAsync(string fileName, byte[] contents)
        {
            try
            {
                var container = await GetBlobContainerAsync(_containerName).ConfigureAwait(false);
                string blobSasUrl = await GetBlobSasUriAsync(container, fileName, contents).ConfigureAwait(false);
                return blobSasUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to saved file : '{fileName}'.");
                throw;
            }
        }

        private async Task<CloudBlobContainer> GetBlobContainerAsync(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(_storageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync().ConfigureAwait(false);
            return container;
        }

        private async Task<string> GetBlobSasUriAsync(CloudBlobContainer container, string fileName, byte[] configurationPayload)
        {
            var blob = container.GetBlockBlobReference(fileName);
            await blob.UploadFromByteArrayAsync(configurationPayload, 0, configurationPayload.Length).ConfigureAwait(false);
            var sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5);
            sasConstraints.SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMonths(Convert.ToInt16(_blobSasExpiryDuration, CultureInfo.InvariantCulture));
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;
            string sasBlobToken = blob.GetSharedAccessSignature(sasConstraints);
            return blob.Uri + sasBlobToken;
        }
    }
}
