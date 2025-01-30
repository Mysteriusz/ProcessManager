using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal static class ProcessProfiler
    {
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessName(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessImageName(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessUser(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessPriority(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetAllProcesses(out uint size);
    }
}
