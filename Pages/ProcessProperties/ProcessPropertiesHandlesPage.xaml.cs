using ProcessManager.Pages.ProcessProperties.Models;
using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;
using ProcessManager.Profiling.Models.Process.Models;
using System.Diagnostics;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesHandlesPage.xaml
    /// </summary>
    public partial class ProcessPropertiesHandlesPage : Page, IProcessPropertiesPage
    {
        //
        //---------------------------------- PROPERTIES ----------------------------------
        //
     
        public ulong ProcessInfoUpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.PROCESS_PIF_HANDLES_INFO);
        public ulong ThreadInfoUpdateFlags { get; set; } = 0;
        public ulong HandleInfoUpdateFlags { get; set; } = (ulong)(ProcessHandleInfoFlags.PROCESS_HIF_NAME | ProcessHandleInfoFlags.PROCESS_HIF_TYPE | ProcessHandleInfoFlags.PROCESS_HIF_ADDRESS);
        public ulong ModuleInfoUpdateFlags { get; set; } = 0;
        public ulong IOInfoUpdateFlags { get; set; } = 0;
        public ulong MemoryInfoUpdateFlags { get; set; } = 0;
        public ulong TimesInfoUpdateFlags { get; set; } = 0;
        public ulong CpuInfoUpdateFlags { get; set; } = 0;

        public int UpdateDelay { get; set; } = 1000;
        public CancellationTokenSource? UpdateCancellation { get; set; }
        
        public ProcessInfo? ProcessInfo { get; set; }

        //
        //---------------------------------- CONSTRUCTORS ----------------------------------
        //

        public ProcessPropertiesHandlesPage()
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

            if (ProcessInfo == null)
                throw new Exception();

            IntPtr ptr = ProcessProfiler.GetProcessInfo(ProcessInfoUpdateFlags, ModuleInfoUpdateFlags, HandleInfoUpdateFlags, ThreadInfoUpdateFlags, TimesInfoUpdateFlags, MemoryInfoUpdateFlags, CpuInfoUpdateFlags, IOInfoUpdateFlags, ProcessInfo.PID);
            ProcessInfoStruct info = Profiler.ToStruct<ProcessInfoStruct>(ptr);
            ProcessInfo.Load(info, ProcessInfoUpdateFlags, ModuleInfoUpdateFlags, HandleInfoUpdateFlags, ThreadInfoUpdateFlags, TimesInfoUpdateFlags, MemoryInfoUpdateFlags, CpuInfoUpdateFlags, IOInfoUpdateFlags);
            ProcessProfiler.FreeProcessInfo(ptr);
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
    }
}
