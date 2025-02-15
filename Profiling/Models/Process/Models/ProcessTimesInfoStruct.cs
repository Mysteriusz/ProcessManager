using ProcessManager.Profiling.Models.Sys;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process.Models
{
    [Flags]
    public enum ProcessTimesInfoFlags : ulong
    {
        PROCESS_TIF_CREATION_TIME = 0x00000001,
        PROCESS_TIF_KERNEL_TIME = 0x00000002,
        PROCESS_TIF_EXIT_TIME = 0x00000004,
        PROCESS_TIF_USER_TIME = 0x00000008,
        PROCESS_TIF_TOTAL_TIME = 0x00000010,
        PROCESS_TIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessTimesInfoStruct
    {
        public Filetime creationTime;
        public Filetime kernelTime;
        public Filetime exitTime;
        public Filetime userTime;
        public Filetime totalTime;
    }
}
