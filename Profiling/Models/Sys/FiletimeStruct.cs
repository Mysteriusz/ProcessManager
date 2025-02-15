using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Sys
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Filetime
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;
    }
}
