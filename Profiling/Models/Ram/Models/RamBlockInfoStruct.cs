using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Ram.Models
{
    [Flags]
    public enum RamBlockInfoFlags : ulong
    {
        RAM_BIF_DEVICE_LOCATOR = 0x00000001,
        RAM_BIF_BANK_LOCATOR = 0x00000002,
        RAM_BIF_VENDOR = 0x00000004,
        RAM_BIF_ARR_HANDLE = 0x00000008,
        RAM_BIF_ERR_INFO_HANDLE = 0x00000010,
        RAM_BIF_TOTAL_WIDTH = 0x00000020,
        RAM_BIF_DATA_WIDTH = 0x00000040,
        RAM_BIF_TYPE_DETAIL = 0x00000080,
        RAM_BIF_SIZE = 0x00000100,
        RAM_BIF_SPEED = 0x00000200,
        RAM_BIF_MIN_VOLTAGE = 0x00000400,
        RAM_BIF_MAX_VOLTAGE = 0x00000800,
        RAM_BIF_CONFIG_VOLTAGE = 0x00001000,
        RAM_BIF_FORM_FACTOR = 0x00002000,
        RAM_BIF_DEVICE_SET = 0x00004000,
        RAM_BIF_MEMORY_TYPE = 0x00008000,
        RAM_BIF_EXTENDED_SIZE = 0x00010000,
        RAM_BIF_ALL = 0xffffffff
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct RamBlockInfoStruct
    {
        public IntPtr deviceLocator;
        public IntPtr bankLocator;
        public IntPtr vendor;

        public UInt16 arrHandle;
        public UInt16 errInfoHandle;
        public UInt16 totalWidth;
        public UInt16 dataWidth;
        public UInt16 typeDetail;
        public UInt16 size;
        public UInt16 speed;

        public UInt16 minVoltage;
        public UInt16 maxVoltage;
        public UInt16 configVoltage;

        public Byte formFactor;
        public Byte deviceSet;
        public Byte memoryType;

        public UInt32 extendedSize;
    }
}
