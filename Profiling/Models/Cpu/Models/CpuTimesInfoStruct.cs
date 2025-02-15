using ProcessManager.Profiling.Models.Sys;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Cpu.Models
{
    [Flags]
    public enum CpuTimesInfoFlags : ulong
    {
        CPU_TIF_USER_TIME = 0x00000001,
        CPU_TIF_KERNEL_TIME = 0x00000002,
        CPU_TIF_IDLE_TIME = 0x00000004,
        CPU_TIF_INTERRUPT_TIME = 0x00000008,
        CPU_TIF_DPC_TIME = 0x00000010,
        CPU_TIF_WORK_TIME = 0x00000020,
        CPU_TIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CpuTimesInfoStruct
    {
        public Filetime workTime;
        public Filetime kernelTime;
        public Filetime idleTime;
        public Filetime dpcTime;
        public Filetime interruptTime;
        public Filetime userTime;
    }
}
