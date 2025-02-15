using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process.Models
{
    [Flags]
    public enum ProcessCpuInfoFlags : ulong
    {
        PROCESS_CIF_USAGE = 0x00000001,
        PROCESS_CIF_CYCLES = 0x00000002,
        PROCESS_CIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessCpuInfoStruct
    {
        public Double usage;
        public UInt64 cycles;
    }
}
