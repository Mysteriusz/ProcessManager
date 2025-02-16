using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GpuInfoStruct
    {
        GpuModelInfoStruct modelInfo;
    };
}
