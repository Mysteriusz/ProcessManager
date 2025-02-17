using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    struct GpuPhysicalInfoStruct
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
