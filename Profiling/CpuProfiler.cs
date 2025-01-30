using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal static class CpuProfiler
    {
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeCpuProfiler();
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeProcessCpuProfiler(uint pid);

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetCpuUsage();
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessCpuUsage(uint pid);        
    }
}
