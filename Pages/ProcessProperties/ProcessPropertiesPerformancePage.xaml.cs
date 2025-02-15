using ProcessManager.Profiling.Models.Process.Models;
using ProcessManager.Pages.ProcessProperties.Models;
using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Diagnostics;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesPerformancePage.xaml
    /// </summary>
    public partial class ProcessPropertiesPerformancePage : Page, IProcessPropertiesPage
    {
        //
        //---------------------------------- PROPERTIES ----------------------------------
        //

        public ulong ProcessInfoUpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.PROCESS_PIF_CPU_INFO | ProcessInfoFlags.PROCESS_PIF_MEMORY_INFO);
        public ulong ThreadInfoUpdateFlags { get; set; } = 0;
        public ulong HandleInfoUpdateFlags { get; set; } = 0;
        public ulong ModuleInfoUpdateFlags { get; set; } = 0;
        public ulong IOInfoUpdateFlags { get; set; } = 0;
        public ulong MemoryInfoUpdateFlags { get; set; } = (ulong)(ProcessMemoryInfoFlags.PROCESS_EIF_VIRTUAL_BYTES);
        public ulong TimesInfoUpdateFlags { get; set; } = 0;
        public ulong CpuInfoUpdateFlags { get; set; } = (ulong)(ProcessCpuInfoFlags.PROCESS_CIF_ALL);

        public int UpdateDelay { get; set; } = 1000;
        public CancellationTokenSource? UpdateCancellation { get; set; }

        public ProcessInfo? ProcessInfo { get; set; }

        //
        //---------------------------------- CONSTRUCTORS ----------------------------------
        //

        public ProcessPropertiesPerformancePage()
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

                    Debug.WriteLine(str.cpuInfo.usage);

                    await Task.Delay(UpdateDelay);
                }
            });
        }
    }
}
