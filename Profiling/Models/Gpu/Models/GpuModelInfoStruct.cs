using System;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    [StructLayout(LayoutKind.Sequential)]
    struct GpuModelInfoStruct
    {
        public IntPtr name;
        public IntPtr vendor;
        public IntPtr driverName;

        public UInt64 driverVersion;

        public UInt32 id;
        public UInt32 revision;
    };
}
