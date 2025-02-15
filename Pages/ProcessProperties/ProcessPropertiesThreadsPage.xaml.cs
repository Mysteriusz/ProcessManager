using ProcessManager.Pages.ProcessProperties.Models;
using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Windows;
using ProcessManager.Profiling.Models.Process.Models;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesThreadsPage.xaml
    /// </summary>
    public partial class ProcessPropertiesThreadsPage : Page, IProcessPropertiesPage
    {
        //
        //---------------------------------- PROPERTIES ----------------------------------
        //

        public ulong ProcessInfoUpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.PROCESS_PIF_THREADS_INFO);
        public ulong ThreadInfoUpdateFlags { get; set; } = (ulong)(ProcessThreadInfoFlags.PROCESS_RIF_ALL);
        public ulong HandleInfoUpdateFlags { get; set; } = 0;
        public ulong ModuleInfoUpdateFlags { get; set; } = 0;
        public ulong IOInfoUpdateFlags { get; set; } = 0;
        public ulong MemoryInfoUpdateFlags { get; set; } = 0;
        public ulong TimesInfoUpdateFlags { get; set; } = 0;
        public ulong CpuInfoUpdateFlags { get; set; } = 0;

        public int UpdateDelay { get; set; } = 5000;
        public CancellationTokenSource? UpdateCancellation { get; set; }

        public ProcessInfo? ProcessInfo { get; set; }

        //
        //---------------------------------- CONSTRUCTORS ----------------------------------
        //

        public ProcessPropertiesThreadsPage()
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
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        IntPtr ptr = ProcessProfiler.GetProcessInfo(ProcessInfoUpdateFlags, ModuleInfoUpdateFlags, HandleInfoUpdateFlags, ThreadInfoUpdateFlags, TimesInfoUpdateFlags, MemoryInfoUpdateFlags, CpuInfoUpdateFlags, IOInfoUpdateFlags, ProcessInfo.PID);
                        ProcessInfoStruct str = Profiler.ToStruct<ProcessInfoStruct>(ptr);
                        ProcessInfo.Load(str, ProcessInfoUpdateFlags, ModuleInfoUpdateFlags, HandleInfoUpdateFlags, ThreadInfoUpdateFlags, TimesInfoUpdateFlags, MemoryInfoUpdateFlags, CpuInfoUpdateFlags, IOInfoUpdateFlags);
                        ProcessProfiler.FreeProcessInfo(ptr);
                    });

                    await Task.Delay(UpdateDelay);
                }
            });
        }
    }
}
