using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    [Flags]
    public enum GpuResolutionInfoFlags : ulong
    {
        GPU_RIF_WIDTH = 0x00000001,
        GPU_RIF_HEIGHT = 0x00000002,
        GPU_RIF_ALL = 0xFFFFFFFF
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct GpuResolutionInfoStruct
    {
        public UInt32 width;
        public UInt32 height;
    };
}
