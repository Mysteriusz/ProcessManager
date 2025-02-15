using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Cpu.Models
{
    [Flags]
    public enum CpuSystemInfoFlags : ulong
    {
        CPU_SIF_SOCKETS = 0x00000001,
        CPU_SIF_CORES = 0x00000002,
        CPU_SIF_THREADS = 0x00000004,
        CPU_SIF_NUMA_COUNT = 0x00000008,
        CPU_SIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CpuSystemInfoStruct
    {
        public uint sockets;
        public uint cores;
        public uint threads;
        public uint numaCount;
    }
}
