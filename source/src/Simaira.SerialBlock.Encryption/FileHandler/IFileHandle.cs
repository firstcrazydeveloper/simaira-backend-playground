namespace Simaira.SerialBlock.Encryption.FileHandler
{
    using System.IO;
    using Simaira.SerialBlock.Encryption.Models;

    public interface IFileHandle
    {
        bool Exists(string path);

        bool Save(string path, Key keyFile, byte[] privateKeyContents);

        byte[] Read(string path, Key keyFile);

        bool DirectoryExists(string path);

        DirectoryInfo CreateDirectory(string path);
    }
}
