using ProcessManager.Profiling.Models.Process.Models;
using ProcessManager.Pages.ProcessProperties.Models;
using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesStatisticsPage.xaml
    /// </summary>
    public partial class ProcessPropertiesStatisticsPage : Page, IProcessPropertiesPage
    {
        //
        //---------------------------------- PROPERTIES ----------------------------------
        //

        public ulong ProcessInfoUpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.PROCESS_PIF_TIMES | ProcessInfoFlags.PROCESS_PIF_HANDLES_INFO | ProcessInfoFlags.PROCESS_PIF_CPU_INFO | ProcessInfoFlags.PROCESS_PIF_MEMORY_INFO | ProcessInfoFlags.PROCESS_PIF_IO_INFO);
        public ulong ThreadInfoUpdateFlags { get; set; } = 0;
        public ulong HandleInfoUpdateFlags { get; set; } = 0;
        public ulong ModuleInfoUpdateFlags { get; set; } = 0;
        public ulong IOInfoUpdateFlags { get; set; } = (ulong)(ProcessIOInfoFlags.PROCESS_OIF_ALL);
        public ulong MemoryInfoUpdateFlags { get; set; } = (ulong)(ProcessMemoryInfoFlags.PROCESS_EIF_ALL);
        public ulong TimesInfoUpdateFlags { get; set; } = (ulong)(ProcessTimesInfoFlags.PROCESS_TIF_KERNEL_TIME | ProcessTimesInfoFlags.PROCESS_TIF_USER_TIME | ProcessTimesInfoFlags.PROCESS_TIF_TOTAL_TIME);
        public ulong CpuInfoUpdateFlags { get; set; } = (ulong)(ProcessCpuInfoFlags.PROCESS_CIF_CYCLES);

        public int UpdateDelay { get; set; } = 1000;
        public CancellationTokenSource? UpdateCancellation { get; set; }

        public ProcessInfo? ProcessInfo { get; set; }

        //
        //---------------------------------- CONSTRUCTORS ----------------------------------
        //

        public ProcessPropertiesStatisticsPage()
        {
            InitializeComponent();
        }

        //
        //---------------------------------- EVENTS ----------------------------------
        //

        public void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ProcessInfo = DataContext as ProcessInfo;
            UpdateCancellation = new CancellationTokenSource();

            UpdateTask().Start();
        }
        public void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ProcessInfo?.Unload(ProcessInfoUpdateFlags, ModuleInfoUpdateFlags, HandleInfoUpdateFlags, ThreadInfoUpdateFlags, TimesInfoUpdateFlags, MemoryInfoUpdateFlags, CpuInfoUpdateFlags, IOInfoUpdateFlags);

            UpdateCancellation?.Cancel();
            UpdateCancellation?.Dispose();

            UpdateCancellation = null;
            ProcessInfo = null;

            GC.Collect();
        }

        public Task UpdateTask()
        {
            return new Task(async () =>
            {
                if (UpdateCancellation == null || ProcessInfo == null)
                    return;

                while (UpdateCancellation != null && !UpdateCancellation.IsCancellationRequested)
                {
                    IntPtr ptr = ProcessProfiler.GetProcessInfo(ProcessInfoUpdateFlags, ModuleInfoUpdateFlags, HandleInfoUpdateFlags, ThreadInfoUpdateFlags, TimesInfoUpdateFlags, MemoryInfoUpdateFlags, CpuInfoUpdateFlags, IOInfoUpdateFlags, ProcessInfo.PID);
                    ProcessInfoStruct str = Profiler.ToStruct<ProcessInfoStruct>(ptr);
                    ProcessInfo.Load(str, ProcessInfoUpdateFlags, ModuleInfoUpdateFlags, HandleInfoUpdateFlags, ThreadInfoUpdateFlags, TimesInfoUpdateFlags, MemoryInfoUpdateFlags, CpuInfoUpdateFlags, IOInfoUpdateFlags);
                    ProcessProfiler.FreeProcessInfo(ptr);
                
                    await Task.Delay(UpdateDelay);
                }
            });
        }
    }
}
