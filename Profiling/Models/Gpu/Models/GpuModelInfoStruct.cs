using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GpuModelInfoStruct
    {
        public IntPtr name;
        public IntPtr vendor;
    };
}
