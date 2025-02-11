using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process
{
    [Flags]
    public enum HandleInfoFlags : ulong
    {
        HandleName = 0x00000001,
        HandleType = 0x00000002,
        HandleAddress = 0x00000004,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessHandleInfoStruct
    {
        public IntPtr name;
        public IntPtr type;
        public UInt64 address;
    }
}
