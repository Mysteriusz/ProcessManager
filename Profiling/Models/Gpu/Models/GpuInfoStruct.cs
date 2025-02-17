using ProcessManager.Profiling.Models.Cpu.Models;
using System;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    [StructLayout(LayoutKind.Sequential)]
    struct GpuInfoStruct
    {
        public IntPtr dxSupport;

        public Double vRamUsage;
        public Double vRamSize;

        public GpuUtilizationInfoStruct utilInfo;
        public GpuResolutionInfoStruct maxResInfo;
        public GpuResolutionInfoStruct minResInfo;
        public GpuModelInfoStruct modelInfo;
    };
}
