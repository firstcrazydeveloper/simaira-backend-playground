namespace Simaira.SerialBlock.Encryption
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Simaira.SerialBlock.Encryption.Application;
    using Simaira.SerialBlock.Encryption.FileHandler;

    public class SerialBlockEncryption
    {
        public static void Main(string[] args)
        {
            var serviceProvide = CreateServiceProvider();
            var asymmetricEncryption = serviceProvide.GetRequiredService<IAsymmetricEncryption>();
            var logger = serviceProvide.GetRequiredService<ILogger<SerialBlockEncryption>>();
            string location = string.Empty;
            Console.WriteLine("Please provide target location to sync your files!");
            location = Console.ReadLine();
            var key = asymmetricEncryption.GeneratepPotectKey(location);
            asymmetricEncryption.ValidateProtectedData(location, key);
        }

        private static IServiceProvider CreateServiceProvider()
        {

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(logger => logger.AddConsole());
            serviceCollection.AddSingleton<IAsymmetricEncryption, AsymmetricEncryption>();
            serviceCollection.AddSingleton<IFileHandle, FileWrapper>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
