using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManager.Profiling.Models.Gpu.Models
{
    struct GpuUtilizationInfoStruct
    {
        public Double utilization;
        public Double videoEncode;
        public Double videoDecode;
        public Double copy;
    };
}
