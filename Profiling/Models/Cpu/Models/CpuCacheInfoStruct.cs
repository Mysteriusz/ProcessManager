using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Cpu.Models
{
    [Flags]
    public enum CpuCacheInfoFlags : ulong
    {
        CPU_HIF_MAX_CORES = 0x00000001,
        CPU_HIF_MAX_THREADS = 0x00000002,
        CPU_HIF_ASSOCIATIVE = 0x00000004,
        CPU_HIF_SELF_INITIALIZING = 0x00000008,
        CPU_HIF_LEVEL = 0x00000010,
        CPU_HIF_TYPE = 0x00000020,
        CPU_HIF_WAYS = 0x00000040,
        CPU_HIF_LINE_COUNT = 0x00000080,
        CPU_HIF_LINE_SIZE = 0x00000100,
        CPU_HIF_SET_COUNT = 0x00000200,
        CPU_HIF_COMPLEX_INDEXING = 0x00000400,
        CPU_HIF_INCLUSIVE = 0x00000800,
        CPU_HIF_WBINVD = 0x00001000,
        CPU_HIF_SIZE = 0x00002000,
        CPU_HIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CpuCacheInfoStruct
    {
        // EAX
        public uint maxCores;
        public uint maxThreads;
        public bool associative;
        public bool selfInitializing;
        public uint level;
        public uint type;

        // EBX
        public uint ways;
        public uint lineCount;
        public uint lineSize;

        // ECX
        public uint setCount;

        // EDX
        public bool complexIndexing;
        public bool inclusive;
        public bool wbinvd;

        // CUSTOM
        public uint size;
    }
}
