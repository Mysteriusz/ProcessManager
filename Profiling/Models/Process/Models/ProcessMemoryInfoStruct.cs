using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process.Models
{
    [Flags]
    public enum ProcessMemoryInfoFlags : ulong
    {
        PROCESS_EIF_PRIVATE_BYTES = 0x00000001,
        PROCESS_EIF_PEAK_PRIVATE_BYTES = 0x00000002,
        PROCESS_EIF_VIRTUAL_BYTES = 0x00000004,
        PROCESS_EIF_PEAK_VIRTUAL_BYTES = 0x00000008,
        PROCESS_EIF_PAGE_FAULTS = 0x00000010,
        PROCESS_EIF_WORKING_BYTES = 0x00000020,
        PROCESS_EIF_PEAK_WORKING_BYTES = 0x00000040,
        PROCESS_EIF_PAGE_PRIORITY = 0x00000080,
        PROCESS_EIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessMemoryInfoStruct
    {
        public UInt32 privateBytes;
        public UInt32 peakPrivateBytes;
        public UInt32 virtualBytes;
        public UInt32 peakVirtualBytes;
        public UInt32 pageFaults;
        public UInt32 workingBytes;
        public UInt32 peakWorkingBytes;
        public UInt64 priority;
    };
}
