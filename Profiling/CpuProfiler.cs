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
        public static extern IntPtr GetCpuLevel1CacheSize();

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuLevel2CacheSize();

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuLevel3CacheSize();

        //
        // ---------------------------------- DOUBLE ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuUsage();

        //
        // ---------------------------------- CPU_TIMES_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath)]
        public static extern IntPtr GetCpuTimes();
    }
}
