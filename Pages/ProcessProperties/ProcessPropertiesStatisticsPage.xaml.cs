using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Diagnostics;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesStatisticsPage.xaml
    /// </summary>
    public partial class ProcessPropertiesStatisticsPage : Page
    {
        public ulong UpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.ProcessTimes | ProcessInfoFlags.ProcessHandlesInfo | ProcessInfoFlags.ProcessCycleCount | ProcessInfoFlags.ProcessMemoryInfo | ProcessInfoFlags.ProcessIOInfo);
        public int UpdateDelay { get; set; } = 1000;
        public ProcessInfo? Process { get; set; }
        public CancellationTokenSource? Token { get; set; }

        public ProcessPropertiesStatisticsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Process = DataContext as ProcessInfo;
            Token = new CancellationTokenSource();

            UpdateTask().Start();
        }
        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Process?.Unload(UpdateFlags, 0, 0);

            Token?.Cancel();
            Token?.Dispose();

            Token = null;
            Process = null;

            GC.Collect();
        }

        public Task UpdateTask()
        {
            return new Task(async () =>
            {
                if (Token == null || Process == null)
                    return;

                while (Token != null && !Token.IsCancellationRequested)
                {
                    IntPtr ptr = ProcessProfiler.GetProcessInfo(UpdateFlags, 0, 0, Process.PID);
                    ProcessInfoStruct str = Profiler.ToStruct<ProcessInfoStruct>(ptr);
                    Process.Read(UpdateFlags, 0, 0, str);

                    ProcessProfiler.FreeProcessInfo(ptr);
                
                    await Task.Delay(UpdateDelay);
                }
            });
        }
    }
}
