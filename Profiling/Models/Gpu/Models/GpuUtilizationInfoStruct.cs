using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    [Flags]
    public enum GpuUtilizationInfoFlags : ulong
    {
        GPU_UIF_UTILIZATION = 0x00000001,
        GPU_UIF_VIDEO_ENCODE = 0x00000002,
        GPU_UIF_VIDEO_DECODE = 0x00000004,
        GPU_UIF_COPY = 0x00000008,
        GPU_UIF_ALL = 0xFFFFFFFF
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct GpuUtilizationInfoStruct
    {
        public Double utilization;
        public Double videoEncode;
        public Double videoDecode;
        public Double copy;
    };
}
