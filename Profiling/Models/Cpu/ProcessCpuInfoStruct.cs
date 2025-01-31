using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Cpu
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessCpuInfoStruct
    {
        ulong lastCPU;
        ulong lastUserCPU;
        ulong lastSysCPU;
        int numProcessors;
        
        double usagePercent;
    }
}
