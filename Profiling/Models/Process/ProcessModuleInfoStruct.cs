using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessModuleInfoStruct
    {
        public IntPtr name;
        public IntPtr path;
        public IntPtr description;
        public UInt64 address;
        public UInt64 size;
    }
}
