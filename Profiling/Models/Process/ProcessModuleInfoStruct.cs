using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManager.Profiling.Models.Process
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessModuleInfoStruct
    {
        public IntPtr name;
        public IntPtr path;
        public IntPtr description;
        public UInt64 address;
        public UInt64 size;
    }
}
