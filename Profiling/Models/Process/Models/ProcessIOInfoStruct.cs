using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process.Models
{
    [Flags]
    public enum ProcessIOInfoFlags : ulong
    {
        PROCESS_OIF_READS = 0x00000001,
        PROCESS_OIF_READ_BYTES = 0x00000002,
        PROCESS_OIF_WRITES = 0x00000004,
        PROCESS_OIF_WRITE_BYTES = 0x00000008,
        PROCESS_OIF_OTHER = 0x00000010,
        PROCESS_OIF_OTHER_BYTES = 0x00000020,
        PROCESS_OIF_IO_PRIORITY = 0x00000040,
        PROCESS_OIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessIOInfoStruct
    {
        public UInt64 reads;
        public UInt64 readBytes;
        public UInt64 writes;
        public UInt64 writeBytes;
        public UInt64 other;
        public UInt64 otherBytes;
        public UInt32 ioPriority;
    };
}
