﻿using System.Runtime.InteropServices;

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
        ProcessHandlesInfo = 0x00002000,
        ProcessCpuInfo = 0x00004000,
        ProcessMemoryInfo = 0x00008000,
        ProcessIOInfo = 0x00010000,
        ProcessModulesInfo = 0x00020000,
        ProcessThreadsInfo = 0x00040000,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
        public UInt32 dwLowDateTime;
        public UInt32 dwHighDateTime;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessTimesInfoStruct
    {
        public FILETIME creationTime;
        public FILETIME kernelTime;
        public FILETIME exitTime;
        public FILETIME userTime;
        public FILETIME totalTime;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessMemoryInfoStruct
    {
        public UInt32 privateBytes;
        public UInt32 peakPrivateBytes;
        public UInt32 virtualBytes;
        public UInt32 peakVirtualBytes;
        public UInt32 pageFaults;
        public UInt32 workingBytes;
        public UInt32 peakWorkingBytes;
        public UInt64 priority;
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessIOInfoStruct
    {
        public UInt64 reads;
        public UInt64 readBytes;
        public UInt64 writes;
        public UInt64 writeBytes;
        public UInt64 other;
        public UInt64 otherBytes;
        public UInt32 ioPriority;
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessCpuInfoStruct
    {
        public Double usage;
        public UInt64 cycles;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessInfoStruct
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
