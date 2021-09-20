namespace Simaira.BlobStorage.Syncing.FileHandler
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Microsoft.Extensions.Logging;
    using Simaira.BlobStorage.Syncing.Models;

    public class FileWrapper : IFileHandle
    {
        private readonly ILogger<FileWrapper> _logger;

        public FileWrapper(ILogger<FileWrapper> logger)
        {
            _logger = logger;
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public bool Save(string path, BlobFile file)
        {
            try
            {
                using (FileStream fs = new FileStream($"{path}/{file.Name}", FileMode.Create))
                {

                    fs.Write(file.Contents, 0, file.Contents.Length);
                }
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to save file : '{file.Name}' on '{path}'.");
                throw;
            }            
        }
    }
}
