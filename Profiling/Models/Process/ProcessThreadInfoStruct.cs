using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessThreadInfoStruct
    {
        public UInt32 priority;
        public UInt32 tid;
        public UInt64 startAddress;
        public UInt64 cyclesDelta;
    }
}
