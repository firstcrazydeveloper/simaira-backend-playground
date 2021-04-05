using System;
using Simaira.BlobStorage.FileStorage;

namespace Simaira.BlobStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileUploadRepository file = new FileUploadRepository();
            string contents = FileReader.GetResourceContent(@"E:\\EdgeModuleDocs.txt");
            string url = file.StringUploadOnBlobStorageAsync(@"EdgeModule.txt", contents).Result;
            Console.ReadKey();
        }
    }
}
