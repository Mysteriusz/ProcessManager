﻿using System;
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
        ProcessHandlesInfo = 0x00002000,
        ProcessCycleCount = 0x00004000,
        ProcessMemoryInfo = 0x00008000,
        ProcessIOInfo = 0x00010000,
        ProcessModulesInfo = 0x00020000,
    }
    [Flags]
    public enum ModuleInfoFlags : ulong
    {
        ModuleName = 0x00000001,
        ModulePath = 0x00000002,
        ModuleDescription = 0x00000004,
        ModuleAddress = 0x00000008,
        ModuleSize = 0x00000010
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessHandlesInfoStruct
    {
        public UInt32 count;
        public UInt32 peakCount;
        public UInt32 gdiCount;
        public UInt32 userCount;
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
        public uint privateBytes;
        public uint peakPrivateBytes;
        public uint virtualBytes;
        public uint peakVirtualBytes;
        public uint pageFaults;
        public uint workingBytes;
        public uint peakWorkingBytes;
        public ulong priority;
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessIOInfoStruct
    {
        public ulong reads;
        public ulong readBytes;
        public ulong writes;
        public ulong writeBytes;
        public ulong other;
        public ulong otherBytes;
        public uint ioPriority;
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessModuleInfoStruct
    {
        public IntPtr name { get; }
        public IntPtr path { get; } 
        public IntPtr description { get; }
        public UInt64 address { get; }
        public UInt64 size { get; }

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
        public UInt64 cycles;

        public ProcessTimesInfoStruct timesInfo;
        public ProcessHandlesInfoStruct handlesInfo;
        public ProcessMemoryInfoStruct memoryInfo;
        public ProcessIOInfoStruct ioInfo;

        public uint moduleCount;
        public IntPtr modules;
    }
}
