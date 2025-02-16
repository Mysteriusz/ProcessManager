using System;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal class GpuProfiler
    {
        //
        // ---------------------------------- STRING ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetGpuName();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetGpuVendor();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetGpuDriverName();

        //
        // ---------------------------------- UINT ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetGpuID();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetGpuRevision();

        //
        // ---------------------------------- ULONG ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetGpuDriverVersion();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetGpuVRamSize();
    }
}
