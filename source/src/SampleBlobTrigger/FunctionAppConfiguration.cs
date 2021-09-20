namespace FunctionAppBlobStorageTrigger
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Extensions.Configuration;

    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {
        public string BlobTrigerName => throw new NotImplementedException();

        public string BlobConnectionString => throw new NotImplementedException();
    }
}
