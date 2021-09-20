namespace FunctionAppBlobStorageTrigger
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IFunctionAppConfiguration
    {
        string BlobTrigerName { get; }
        string BlobConnectionString { get; }
    }
}
