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
        public static extern IntPtr GetProcessCurrentHandleCount(uint pid);

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
        public static extern IntPtr GetProcessCurrentTimes(uint pid, out uint size);

        //
        // ---------------------------------- PROCESS_HANDLES_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessHandlesInfo(uint pid);

        //
        // ---------------------------------- PROCESS_MEMORY_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessIOCurrentInfo(uint pid);

        //
        // ---------------------------------- PROCESS_MODULE_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessAllModuleInfo(uint pid, out uint size);

        //
        // ---------------------------------- PROCESS_MEMORY_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessMemoryCurrentInfo(uint pid);

        //
        // ---------------------------------- PROCESS_INFO_STRUCT ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessInfo(ulong infoFlags, uint pid);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr FreeProcessInfo(IntPtr info);
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetAllProcessInfo(ulong infoFlags, out uint size);
    }
}
