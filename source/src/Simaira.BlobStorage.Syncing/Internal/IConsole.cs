namespace Simaira.BlobStorage.Syncing.Internal
{
    using System;

    internal interface IConsole : IDisposable
    {
        event ConsoleCancelEventHandler CancelKeyPress;
    }
}
