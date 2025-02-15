using ProcessManager.Profiling.Models.Process;
using System;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Cpu
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CpuTimesInfoStruct
    {
        public FILETIME workTime;
        public FILETIME kernelTime;
        public FILETIME idleTime;
        public FILETIME dpcTime;
        public FILETIME interruptTime;
        public FILETIME userTime;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct CpuInfoStruct
    {
        public IntPtr vendor;
        public IntPtr name;
        public IntPtr architecture;
        
        public UInt32 model;
        public UInt32 family;
        public UInt32 stepping;
        
        public Double usage;
        public Double currentFreq;
        public Double baseFreq;
        public Double maxFreq;
        public Double temp;
        
        public Double lv1mem;
        public Double lv2mem;
        public Double lv3mem;
        
        public UInt32 sockets;
        public UInt32 cores;
        public UInt32 processors;
        public UInt32 threads;
        public UInt32 entries;
        
        public Boolean virtualization;
        public Boolean hyperThreading;

        public CpuTimesInfoStruct timesInfo;
    }
}
