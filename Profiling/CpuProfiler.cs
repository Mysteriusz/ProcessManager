using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal class CpuProfiler
    {
        //
        // ---------------------------------- STRING ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuName();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuVendor();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuArchitecture();

        //
        // ---------------------------------- UINT32 ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuModel();
        
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuFamily();
        
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuStepping();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuThreadCount();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuHandleCount();

        //
        // ---------------------------------- DOUBLE ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuUsage();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuBaseFrequency();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuMaxFrequency();

        //
        // ---------------------------------- BOOLEAN ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr IsCpuVirtualization();
        [DllImport(Profiler.DllPath)]
        public static extern IntPtr IsCpuHyperThreading();

        //
        // ---------------------------------- CPU_SYSTEM_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuSystemInfo();

        //
        // ---------------------------------- CPU_TIMES_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuTimes();

        //
        // ---------------------------------- CPU_CACHE_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuAllLevelsCacheInfo(out uint size);
    }
}
