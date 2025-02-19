using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Ram.Models
{
    [Flags]
    public enum RamInfoFlags : ulong
    {
        RAM_RIF_LOCATION = 0x00000001,
        RAM_RIF_USE = 0x00000002,
        RAM_RIF_MEM_CORRECTION_ERROR = 0x00000004,
        RAM_RIF_MEM_ERROR_INFO_HANDLE = 0x00000008,
        RAM_RIF_DEVICE_COUNT = 0x00000010,
        RAM_RIF_MAX_CAPACITY = 0x00000020,
        RAM_RIF_EXT_MAX_CAPACITY = 0x00000040,
        RAM_RIF_BLOCK_INFOS = 0x00000080,
        RAM_RIF_UTILIZATION_INFO = 0x00000100,
        RAM_RIF_ALL = 0xffffffff
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct RamInfoStruct
    {
        public Byte location;
        public Byte use;
        public Byte memCorrectionError;

        public UInt16 memErrorInfoHandle;
        public UInt16 deviceCount;

        public UInt32 maxCapacity;
        public UInt64 extMaxCapacity;

        public RamUtilizationInfoStruct utilizationInfo;

        public UInt32 blockCount;
        public IntPtr blocks;
    }
}
