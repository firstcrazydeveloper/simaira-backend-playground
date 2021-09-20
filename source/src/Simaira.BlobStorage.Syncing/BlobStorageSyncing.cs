namespace Simaira.BlobStorage.Syncing
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Simaira.BlobStorage.Syncing.Application;
    using Simaira.BlobStorage.Syncing.BlobStorage;
    using Simaira.BlobStorage.Syncing.FileHandler;
    using Simaira.BlobStorage.Syncing.Internal;

    public class BlobStorageSyncing
    {
        public static async Task Main(string[] args)
        {
            var serviceProvide = CreateServiceProvider();
            var blobStoargeSyncManager = serviceProvide.GetRequiredService<IBlobStorageSyncManager>();
            var logger = serviceProvide.GetRequiredService<ILogger<BlobStorageSyncing>>();
            try
            {
                string location = string.Empty;
                bool isValidInput = false;
                while (!isValidInput)
                {
                    Console.WriteLine("Please provide target location to sync your files!");
                    location = Console.ReadLine();
                    if (!IsValidPath(location))
                    {
                        Console.WriteLine("Your input is wron try again!!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
                logger.LogInformation("Your Request started......");
                await blobStoargeSyncManager.SyncStorage(location).ConfigureAwait(false);
                logger.LogInformation("Your Request completed......");
                Console.ReadKey();
            }           
            catch(Exception ex)
            {
                logger.LogError(ex, $"Failed to synced files from blob storage.");
                throw;
            }
        }

        private static bool IsValidPath(string path, bool allowRelativePaths = false)
        {
            bool isValid = true;

            try
            {
                string fullPath = Path.GetFullPath(path);

                if (allowRelativePaths)
                {
                    isValid = Path.IsPathRooted(path);
                }
                else
                {
                    string root = Path.GetPathRoot(path);
                    isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
            }

            return isValid;
        }

        private static IServiceProvider CreateServiceProvider()
        {

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(logger => logger.AddConsole());
            serviceCollection.AddSingleton<IConsole, ConsoleWrapper>();
            serviceCollection.AddSingleton<IDebugger, DebuggerWrapper>();
            serviceCollection.AddSingleton<IDirectory, DirectoryWrapper>();
            serviceCollection.AddSingleton<IFileHandle, FileWrapper>();
            serviceCollection.AddSingleton<IBlobFileRepository, BlobFileRepository>();
            serviceCollection.AddSingleton<IBlobStorageSyncManager, BlobStorageSyncManager>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
