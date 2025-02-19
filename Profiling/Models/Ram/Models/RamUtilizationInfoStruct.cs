using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Ram.Models
{
    [Flags]
    public enum RamUtilizationInfoFlags : ulong
    {
        RAM_UIF_TOTAL_PHYSICAL_MEMORY = 0x00000001,
        RAM_UIF_TOTAL_VIRTUAL_MEMORY = 0x00000002,
        RAM_UIF_TOTAL_PAGE_MEMORY = 0x00000004,
        RAM_UIF_AVAILABLE_PHYSICAL_MEM = 0x00000008,
        RAM_UIF_AVAILABLE_VIRTUAL_MEM = 0x00000010,
        RAM_UIF_AVAILABLE_PAGE_MEM = 0x00000020,
        RAM_UIF_MEMORY_LOAD = 0x00000040,
        RAM_UIF_ALL = 0xffffffff
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct RamUtilizationInfoStruct
    {
        public UInt64 totalPhysicalMemory;
        public UInt64 totalVirtualMemory;
        public UInt64 totalPageMemory;

        public UInt64 availablePhysicalMemory;
        public UInt64 availableVirtualMemory;
        public UInt64 availablePageMemory;

        public UInt32 memoryLoad;
    }
}
