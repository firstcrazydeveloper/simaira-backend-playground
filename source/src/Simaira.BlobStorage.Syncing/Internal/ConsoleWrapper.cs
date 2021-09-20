
namespace Simaira.BlobStorage.Syncing.Internal
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    internal class ConsoleWrapper : IConsole
    {
        public ConsoleWrapper()
        {
            Console.CancelKeyPress += OnCancelKeyPress;
        }

        public event ConsoleCancelEventHandler CancelKeyPress;

        public void Dispose()
        {
            Console.CancelKeyPress -= OnCancelKeyPress;
        }

        protected virtual void OnCancelKeyPress(object sender, ConsoleCancelEventArgs consoleCancelEventArgs)
        {
            CancelKeyPress?.Invoke(sender, consoleCancelEventArgs);
        }
    }
}
