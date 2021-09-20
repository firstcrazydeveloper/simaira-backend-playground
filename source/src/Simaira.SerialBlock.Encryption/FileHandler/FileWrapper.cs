namespace Simaira.SerialBlock.Encryption.FileHandler
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Logging;
    using Simaira.SerialBlock.Encryption.Models;

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

        public bool Save(string path, Key keyFile, byte[] privateKeyContents)
        {
            try
            {
                using (FileStream fs = new FileStream($"{path}/{keyFile.FileName}", FileMode.Create))
                {

                    fs.Write(privateKeyContents, 0, privateKeyContents.Length);
                }
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to save file : '{keyFile.FileName}' on '{path}'.");
                throw;
            }            
        }

        public byte[] Read(string path, Key keyFile)
        {
            try
            {
                byte[] keyContents;

                using (FileStream fs = new FileStream($"{path}/{keyFile.FileName}", FileMode.Open))
                {
                    keyContents = new byte[fs.Length];
                    fs.Read(keyContents, 0, (int)fs.Length);
                }
                return keyContents;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to save file : '{keyFile.FileName}' on '{path}'.");
                throw;
            }
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public DirectoryInfo CreateDirectory(string path)
        {
            return Directory.CreateDirectory(path);
        }
    }
}
