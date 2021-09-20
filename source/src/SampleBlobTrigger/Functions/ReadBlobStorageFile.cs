namespace FunctionAppBlobStorageTrigger.Functions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;

    public class ReadBlobStorageFile
    {
        [FunctionName("GetFileFromBlobStorage")]
        public async Task GetFileFromBlobStorage([BlobTrigger("%BlobTriggerName%/{name}", Connection = "BlobConnectionString")]
                                                        Stream blobFileContents, string blobTrigger, string name)
        {
            await Task.Run(() => Play());

        }

        private void Play()
        {

        }
    }
}
