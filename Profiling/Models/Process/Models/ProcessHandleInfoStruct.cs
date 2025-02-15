using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process.Models
{
    [Flags]
    public enum ProcessHandleInfoFlags : ulong
    {
        PROCESS_HIF_NAME = 0x00000001,
        PROCESS_HIF_TYPE = 0x00000002,
        PROCESS_HIF_ADDRESS = 0x00000004,
        PROCESS_HIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessHandleInfoStruct
    {
        public IntPtr name;
        public IntPtr type;
        public UInt64 address;
    }
}
