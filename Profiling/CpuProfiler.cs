using System.Runtime.InteropServices;
using ProcessManager.Profiling.Models.Cpu;
using ProcessManager.Profiling.Models.Process;

namespace ProcessManager.Profiling
{
    internal static class CpuProfiler
    {
        //
        // ---------------------------------- EXTERNAL ----------------------------------
        //

        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern void InitializeCpuProfiler();
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern void InitializeProcessCpuProfiler(uint pid);

        /// <returns><see cref="double"/> Pointer.</returns>
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetCpuUsage();

        /// <returns><see cref="double"/> Pointer.</returns>
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetProcessCpuUsage(uint pid);

        /// <returns><see cref="CpuInfoStruct"/> Pointer.</returns>
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetCpuInfo();

        /// <returns><see cref="ProcessCpuInfoStruct"/> Pointer.</returns>
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetProcessCpuInfo(uint pid);

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        public static bool TryInitializeCpuProfiler(out Exception? exception)
        {
            try
            {
                InitializeCpuProfiler();
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }
        public static bool TryInitializeProcessCpuProfiler(uint pid, out Exception? exception)
        {
            try
            {
                InitializeProcessCpuProfiler(pid);
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool TryGetCpuUsage(out double cpuUsage)
        {
            try
            {
                cpuUsage = Marshal.PtrToStructure<double>(GetCpuUsage());
                return true;
            }
            catch
            {
                cpuUsage = -1;
                return false;
            }
        }
        public static bool TryGetProcessCpuUsage(uint pid, out double cpuUsage)
        {
            try
            {
                cpuUsage = Marshal.PtrToStructure<double>(GetProcessCpuUsage(pid));
                return true;
            }
            catch
            {
                cpuUsage = -1;
                return false;
            }
        }

        public static bool TryGetCpuInfo(out CpuInfoStruct? cpuInfo)
        {
            try
            {
                IntPtr ptr = GetCpuInfo();
                IntPtr currentProcessPtr = ptr + Marshal.SizeOf<CpuInfoStruct>();
                cpuInfo = Marshal.PtrToStructure<CpuInfoStruct>(currentProcessPtr);
                return true;
            }
            catch
            {
                cpuInfo = null;
                return false;
            }
        }
        public static bool TryGetProcessCpuInfo(uint pid, out ProcessCpuInfoStruct? processCpuInfo)
        {
            try
            {
                IntPtr ptr = GetProcessCpuInfo(pid);
                IntPtr currentProcessPtr = ptr + Marshal.SizeOf<ProcessCpuInfoStruct>();
                processCpuInfo = Marshal.PtrToStructure<ProcessCpuInfoStruct>(currentProcessPtr);
                return true;
            }
            catch
            {
                processCpuInfo = null;
                return false;
            }
        }

    }
}
