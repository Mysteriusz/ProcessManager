using System.Runtime.InteropServices;
using System.Windows.Threading;
using ProcessManager.Profiling.Models.Process;

namespace ProcessManager.Profiling
{
    internal static class ProcessProfiler
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //
        
        public static int DataCollectorInterval { get; set; } = 1000;

        //
        // ---------------------------------- EXTERNAL ----------------------------------
        //

        /// <returns><see cref="char[]"/> Pointer.</returns>
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetProcessName(uint pid);
        
        /// <returns><see cref="char[]"/> Pointer.</returns>
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessImageName(uint pid);
        
        /// <returns><see cref="char[]"/> Pointer.</returns>
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessUser(uint pid);
        
        /// <returns><see cref="char[]"/> Pointer.</returns>
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetProcessPriority(uint pid);

        /// <returns><see cref="ProcessInfoStruct[]"/> Pointer.</returns>
        [DllImport(Profiler.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetAllProcesses(out uint size);

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        public static bool TryGetProcessName(uint pid, out string processName)
        {
            try
            {
                IntPtr ptr = GetProcessName(pid);
                processName = Marshal.PtrToStringAnsi(ptr)!;
                return true;
            }
            catch
            {
                processName = "";
                return false;
            }
        }
        public static bool TryGetProcessImageName(uint pid, out string imageName)
        {
            try
            {
                IntPtr ptr = GetProcessImageName(pid);
                imageName = Marshal.PtrToStringAnsi(ptr)!;
                return true;
            }
            catch
            {
                imageName = "";
                return false;
            }
        }
        public static bool TryGetProcessUser(uint pid, out string user)
        {
            try
            {
                IntPtr ptr = GetProcessUser(pid);
                user = Marshal.PtrToStringAnsi(ptr)!;
                return true;
            }
            catch
            {
                user = "";
                return false;
            }
        }
        public static bool TryGetProcessPriority(uint pid, out string priority)
        {
            try
            {
                IntPtr ptr = GetProcessPriority(pid);
                priority = Marshal.PtrToStringAnsi(ptr)!;
                return true;
            }
            catch
            {
                priority = "";
                return false;
            }
        }
        public static bool TryGetAllProcesses(out ProcessInfoStruct[]? processes)
        {
            try
            {
                IntPtr ptr = GetAllProcesses(out uint size);
                processes = new ProcessInfoStruct[size];

                for (int i = 0; i < size; i++)
                {
                    IntPtr currentProcessPtr = ptr + (i * Marshal.SizeOf<ProcessInfoStruct>());
                    ProcessInfoStruct processStruct = Marshal.PtrToStructure<ProcessInfoStruct>(currentProcessPtr);

                    processes[i] = processStruct;
                }

                return true;
            }
            catch
            {
                processes = null;
                return false;
            }
        }

        public static void StartProcessDataCollector(ProcessInfo process, Dispatcher dispatcher)
        {
            Task.Run(async () =>
            {
                if (!CpuProfiler.TryInitializeProcessCpuProfiler(process.PID, out _))
                {
                    return;
                }

                while (true)
                {
                    await Task.Delay(DataCollectorInterval);
                    CpuProfiler.TryGetProcessCpuUsage(process.PID, out double usage);
                    dispatcher.Invoke(() => process.CpuUsage = Math.Round(usage, 2));
                }
            });
        }
    }
}
