using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process
{
    [Flags]
    public enum ThreadInfoFlags : ulong
    {
        ThreadTid = 0x00000001,
        ThreadCycles = 0x00000002,
        ThreadStartAddress = 0x00000004,
        ThreadPriority = 0x00000008,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessThreadInfoStruct
    {
        public UInt64 priority;
        public UInt64 tid;
        public UInt64 startAddress;
        public UInt64 cyclesDelta;
    }
}
