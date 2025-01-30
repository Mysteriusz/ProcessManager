﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal class Profiler 
    {
        public const string DllPath = "C:\\Users\\wixxx\\source\\repos\\ProcessManager\\ProcessManagerLib\\x64\\Debug\\ProcessManagerLib.dll";
        public static string? ToString(IntPtr ptr)
        {
            try
            {
                return Marshal.PtrToStringUTF8(ptr);
            }
            catch { return ""; }
        }
        public static TStruct? ToStruct<TStruct>(IntPtr ptr)
        {
            return Marshal.PtrToStructure<TStruct>(ptr);
        }
    }
}
