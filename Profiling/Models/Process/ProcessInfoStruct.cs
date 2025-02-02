using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process
{
    [Flags]
    public enum ProcessInfoFlags : ulong
    {
        ProcessName = 0x00000001,
        ProcessParentName = 0x00000002,
        ProcessImageName = 0x00000004,
        ProcessUser = 0x00000008,
        ProcessPriority = 0x00000010,
        ProcessFileVersion = 0x00000020,
        ProcessArchitectureType = 0x00000040,
        ProcessIntegrityLevel = 0x00000080,
        ProcessCommandLine = 0x00000100,
        ProcessDescription = 0x00000200,
        ProcessPEB = 0x00000400,
        ProcessTimes = 0x00000800,
        ProcessPPID = 0x00001000,
        ProcessHandlesInfo = 0x00002000
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FILETIME
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct ProcessHandlesInfoStruct
    {
        public UInt32 count;
        public UInt32 peakCount;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct ProcessTimesInfoStruct
    {
        public FILETIME creationTime;
        public FILETIME kernelTime;
        public FILETIME exitTime;
        public FILETIME userTime;
        public FILETIME totalTime;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct ProcessInfoStruct
    {
        public IntPtr name;
        public IntPtr parentProcessName;
        public IntPtr user;
        public IntPtr imageName;
        public IntPtr priority;
        public IntPtr fileVersion;
        public IntPtr integrityLevel;
        public IntPtr architectureType;
        public IntPtr cmd;
        public IntPtr description;

        public UInt32 pid;
        public UInt32 ppid;
        public UInt64 peb;

        public ProcessTimesInfoStruct timesInfo;
        public ProcessHandlesInfoStruct handlesInfo;
    }
}
