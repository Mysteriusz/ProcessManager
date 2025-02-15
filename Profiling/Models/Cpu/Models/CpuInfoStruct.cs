using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Cpu.Models
{
    [Flags]
    public enum CpuInfoFlags : ulong
    {
        CPU_CIF_USAGE = 0x00000001,
        CPU_CIF_BASE_FREQ = 0x00000002,
        CPU_CIF_MAX_FREQ = 0x00000004,
        CPU_CIF_THREADS = 0x00000008,
        CPU_CIF_HANDLES = 0x00000010,
        CPU_CIF_VIRTUALIZATION = 0x00000020,
        CPU_CIF_HYPER_THREADING = 0x00000040,
        CPU_CIF_CACHE_INFO = 0x00000100,
        CPU_CIF_SYS_INFO = 0x00000200,
        CPU_CIF_MODEL_INFO = 0x00000400,
        CPU_CIF_TIMES_INFO = 0x00000800,
        CPU_CIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CpuInfoStruct
    {
        public double usage;
        public double baseFreq;
        public double maxFreq;

        public uint threads;
        public uint handles;

        public bool virtualization;
        public bool hyperThreading;

        public uint cacheCount;
        public nint cacheInfo;

        public CpuSystemInfoStruct sysInfo;
        public CpuModelInfoStruct modelInfo;
        public CpuTimesInfoStruct timesInfo;
    }
}
