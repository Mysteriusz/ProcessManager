using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Cpu
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CpuInfoStruct
    {
        double cpuSysUsage;
    }
}
