namespace Simaira.BlobStorage.FileStorage
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    public class FileUploadRepository
    {
        private readonly string _storageConnectionString;
        private readonly string _containerName;
        private readonly string _blobSasExpiryDuration;

        public FileUploadRepository()
        {
            _blobSasExpiryDuration = "120";
            _containerName = "simairadevdata";
            _storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=simairadevplayground;AccountKey=6/warCo+JaYzqQIn6fTnNWAwnz4owKnuVQj2qxVyt5KII65bGu9XyIhruQvGZaBmrmYid5vaWz3pgbaaJvU09g==;EndpointSuffix=core.windows.net";
        }

        public async Task<string> StringUploadOnBlobStorageAsync(string fileName, string content)
        {
            var container = await GetBlobContainerAsync(_containerName).ConfigureAwait(false);
            string blobSasUrl = await GetBlobSasUriAsync(container, fileName, content).ConfigureAwait(false);
            return blobSasUrl;
        }

        private async Task<CloudBlobContainer> GetBlobContainerAsync(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(_storageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync().ConfigureAwait(false);
            return container;
        }

        private async Task<string> GetBlobSasUriAsync(CloudBlobContainer container, string fileName, string configurationPayload)
        {
            var blob = container.GetBlockBlobReference(fileName);
            await blob.UploadTextAsync(configurationPayload).ConfigureAwait(false);
            var sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5);
            sasConstraints.SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMonths(Convert.ToInt16(_blobSasExpiryDuration, CultureInfo.InvariantCulture));
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;
            string sasBlobToken = blob.GetSharedAccessSignature(sasConstraints);
            return blob.Uri + sasBlobToken;
        }
    }
}
