namespace Simaira.SerialBlock.Encryption.Application
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using Simaira.SerialBlock.Encryption.FileHandler;
    using Simaira.SerialBlock.Encryption.Models;

    public class AsymmetricEncryption : IAsymmetricEncryption
    {
        private readonly int _keySize = 1024;
        private readonly IFileHandle _fileHandler;
        public AsymmetricEncryption(IFileHandle fileHandler)
        {
            _fileHandler = fileHandler;
        }
        public Key GeneratepPotectKey(string location)
        {
            if (!_fileHandler.DirectoryExists(location))
            {
                _fileHandler.CreateDirectory(location);
            }
            string KeyFileName = Guid.NewGuid().ToString();
            Key keyFile = new Key();
            RSACryptoServiceProvider Algorithm = new RSACryptoServiceProvider(_keySize);
            string CompleteKey = Algorithm.ToXmlString(true);
            byte[] KeyBytes = Encoding.UTF8.GetBytes(CompleteKey);

            KeyBytes = ProtectedData.Protect(KeyBytes,
                            null, DataProtectionScope.LocalMachine);

            keyFile.PublicKey = Algorithm.ToXmlString(false);
            keyFile.FileName = $"{KeyFileName}.config";
            _fileHandler.Save(location, keyFile, KeyBytes);
            
            return keyFile;
        }

        public void ValidateProtectedData(string location, Key keyFile)
        {
            var keyContents = _fileHandler.Read(location, keyFile);
            var KeyBytes = ProtectedData.Unprotect(keyContents,
                          null, DataProtectionScope.CurrentUser);
        }
    }
}
