using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process.Models
{
    [Flags]
    public enum ProcessModuleInfoFlags : ulong
    {
        PROCESS_MIF_NAME = 0x00000001,
        PROCESS_MIF_PATH = 0x00000002,
        PROCESS_MIF_DESCRIPTION = 0x00000004,
        PROCESS_MIF_ADDRESS = 0x00000008,
        PROCESS_MIF_SIZE = 0x00000010,
        PROCESS_MIF_ALL = 0xffffffff
    }

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
