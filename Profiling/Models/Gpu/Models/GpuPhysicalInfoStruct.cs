using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    [Flags]
    public enum GpuPhysicalInfoFlags : ulong
    {
        GPU_PIF_BUS_ID = 0x00000001,
        GPU_PIF_LEGACY_BUS_ID = 0x00000002,
        GPU_PIF_BUS = 0x00000004,
        GPU_PIF_DOMAIN = 0x00000008,
        GPU_PIF_DEVICE_ID = 0x00000010,
        GPU_PIF_PCI_DEVICE_ID = 0x00000020,
        GPU_PIF_SUBSYS_DEVICE_ID = 0x00000040,
        GPU_PIF_ALL = 0xFFFFFFFF
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct GpuPhysicalInfoStruct
    {
        public IntPtr busId;
        public IntPtr legacyBusId;

        public UInt32 bus;
        public UInt32 domain;
        public UInt32 deviceId;
        public UInt32 pciDeviceId;
        public UInt32 subSysDeviceId;
    };


}
