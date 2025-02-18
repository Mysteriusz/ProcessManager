using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    [Flags]
    public enum GpuModelInfoFlags : ulong
    {
        GPU_MIF_NAME = 0x00000001,
        GPU_MIF_VENDOR = 0x00000002,
        GPU_MIF_DRIVER_NAME = 0x00000004,
        GPU_MIF_DRIVER_VERSION = 0x00000008,
        GPU_MIF_ID = 0x00000010,
        GPU_MIF_REVISION = 0x00000020,
        GPU_MIF_ALL = 0xFFFFFFFF
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct GpuModelInfoStruct
    {
        public IntPtr name;
        public IntPtr vendor;
        public IntPtr driverName;

        public UInt64 driverVersion;

        public UInt32 id;
        public UInt32 revision;
    };
}
