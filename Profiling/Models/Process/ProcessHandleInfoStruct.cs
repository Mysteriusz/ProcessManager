﻿using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessHandleInfoStruct
    {
        public IntPtr name;
        public IntPtr type;
        public Int32 address;
    }
}
