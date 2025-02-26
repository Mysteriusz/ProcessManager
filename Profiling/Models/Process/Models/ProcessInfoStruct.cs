using ProcessManager.Profiling.Models.Sys;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process.Models
{
    [Flags]
    public enum ProcessInfoFlags : ulong
    {
        PROCESS_PIF_NAME = 0x00000001,
        PROCESS_PIF_PARENT_NAME = 0x00000002,
        PROCESS_PIF_IMAGE_NAME = 0x00000004,
        PROCESS_PIF_USER = 0x00000008,
        PROCESS_PIF_PRIORITY = 0x00000010,
        PROCESS_PIF_FILE_VERSION = 0x00000020,
        PROCESS_PIF_ARCHITECTURE_TYPE = 0x00000040,
        PROCESS_PIF_INTEGRITY_LEVEL = 0x00000080,
        PROCESS_PIF_COMMAND_LINE = 0x00000100,
        PROCESS_PIF_DESCRIPTION = 0x00000200,
        PROCESS_PIF_PEB = 0x00000400,
        PROCESS_PIF_TIMES = 0x00000800,
        PROCESS_PIF_PPID = 0x00001000,
        PROCESS_PIF_HANDLES_INFO = 0x00002000,
        PROCESS_PIF_CPU_INFO = 0x00004000,
        PROCESS_PIF_MEMORY_INFO = 0x00008000,
        PROCESS_PIF_IO_INFO = 0x00010000,
        PROCESS_PIF_MODULES_INFO = 0x00020000,
        PROCESS_PIF_THREADS_INFO = 0x00040000,
        PROCESS_PIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessInfoStruct
    {
        public IntPtr name;
        public IntPtr parentProcessName;
        public IntPtr user;
        public IntPtr imageName;
        public IntPtr fileVersion;
        public IntPtr integrityLevel;
        public IntPtr architectureType;
        public IntPtr cmd;
        public IntPtr description;

        public UInt64 peb;
        public UInt32 pid;
        public UInt32 ppid;
        public UInt32 priority;

        public ProcessTimesInfoStruct timesInfo;
        public ProcessMemoryInfoStruct memoryInfo;
        public ProcessIOInfoStruct ioInfo;
        public ProcessCpuInfoStruct cpuInfo;

        public UInt32 moduleCount;
        public IntPtr modules;

        public UInt32 handleCount;
        public UInt32 handlePeakCount;
        public UInt32 gdiHandleCount;
        public UInt32 userHandleCount;
        public IntPtr handles;

        public UInt32 threadCount;
        public IntPtr threads;
    }
}
