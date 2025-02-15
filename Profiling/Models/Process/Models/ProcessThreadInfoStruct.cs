using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process.Models
{
    [Flags]
    public enum ProcessThreadInfoFlags : ulong
    {
        PROCESS_RIF_TID = 0x00000001,
        PROCESS_RIF_CYCLES = 0x00000002,
        PROCESS_RIF_START_ADDRESS = 0x00000004,
        PROCESS_RIF_PRIORITY = 0x00000008,
        PROCESS_RIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessThreadInfoStruct
    {
        public UInt64 priority;
        public UInt64 tid;
        public UInt64 startAddress;
        public UInt64 cyclesDelta;
    }
}
