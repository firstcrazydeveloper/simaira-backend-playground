using Simaira.SerialBlock.Encryption.Models;

namespace Simaira.SerialBlock.Encryption.Application
{
    public interface IAsymmetricEncryption
    {
        Key GeneratepPotectKey(string location);
        void ValidateProtectedData(string location, Key keyFile);
    }
}
