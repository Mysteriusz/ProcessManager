using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal static class ProcessProfiler
    {
        //
        // ---------------------------------- STRING ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessName(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessParentName(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessImageName(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessPriority(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessUser(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessFileVersion(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessArchitectureType(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessIntegrityLevel(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessCommandLine(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessDescription(uint pid);

        //
        // ---------------------------------- UINT32 ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessPPID(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessStatus(uint pid);

        //
        // ---------------------------------- UINT64 ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessPEB(uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessCycleCount(uint pid);

        //
        // ---------------------------------- FILETIME ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessCurrentTimes(ulong tif, uint pid, out uint size);

        //
        // ---------------------------------- PROCESS_MEMORY_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessCurrentIOInfo(ulong oif, uint pid);

        //
        // ---------------------------------- PROCESS_MEMORY_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessCurrentMemoryInfo(ulong eif, uint pid);

        //
        // ---------------------------------- PROCESS_CPU_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessCurrentCPUInfo(ulong cif, uint pid);

        //
        // ---------------------------------- PROCESS_MODULE_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessAllModuleInfo(ulong mif, uint pid, out uint size);

        //
        // ---------------------------------- PROCESS_HANDLE_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessAllHandleInfo(ulong hif, uint pid, out uint size);


        //
        // ---------------------------------- PROCESS_THREAD_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessAllThreadInfo(ulong rif, uint pid, out uint size);

        //
        // ---------------------------------- PROCESS_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessInfo(ulong pif, ulong mif, ulong hif, ulong rif, ulong tif, ulong eif, ulong cif, ulong oif, uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FreeProcessInfo(IntPtr info);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetAllProcessInfo(ulong pif, ulong mif, ulong hif, ulong rif, ulong tif, ulong eif, ulong cif, ulong oif, out uint size);
    }
}
