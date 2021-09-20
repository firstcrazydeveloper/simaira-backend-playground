namespace Simaira.BlobStorage.Syncing.Internal
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    internal class DebuggerWrapper : IDebugger
    {
        public bool IsAttached => Debugger.IsAttached;
    }
}
