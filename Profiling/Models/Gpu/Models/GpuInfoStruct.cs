using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    [Flags]
    public enum GpuInfoFlags : ulong
    {
        GPU_GIF_DX_SUPPORT = 0x00000001,
        GPU_GIF_VRAM_USAGE = 0x00000002,
        GPU_GIF_VRAM_SIZE = 0x00000004,
        GPU_GIF_UTILIZATION_INFO = 0x00000008,
        GPU_GIF_PHYSICAL_INFO = 0x00000010,
        GPU_GIF_MAX_RES_INFO = 0x00000020,
        GPU_GIF_MIN_RES_INFO = 0x00000040,
        GPU_GIF_MODEL_INFO = 0x00000080,
        GPU_GIF_ALL = 0xfffffffff,
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct GpuInfoStruct
    {
        public IntPtr dxSupport;

        public Double vRamUsage;
        public Double vRamSize;

        public GpuUtilizationInfoStruct utilInfo;
        public GpuPhysicalInfoStruct physInfo;
        public GpuResolutionInfoStruct maxResInfo;
        public GpuResolutionInfoStruct minResInfo;
        public GpuModelInfoStruct modelInfo;
    };
}
