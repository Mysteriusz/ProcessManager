using ProcessManager.Profiling;
using ProcessManager.Profiling.Models.Process;
using System.Diagnostics;
using System.Windows.Controls;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesStatisticsPage.xaml
    /// </summary>
    public partial class ProcessPropertiesStatisticsPage : Page
    {
        public ulong UpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.ProcessTimes | ProcessInfoFlags.ProcessHandlesInfo | ProcessInfoFlags.ProcessCycleCount);
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

            UpdateThread().Start();
        }
        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Token!.Cancel();
        }

        public Thread UpdateThread()
        {
            return new Thread(async () =>
            {
                if (Token == null || Process == null)
                    return;

                object threadLock = new object();

                while (!Token.IsCancellationRequested)
                {
                    await Task.Delay(UpdateDelay);
                    
                    lock (threadLock)
                    {
                        ProcessInfoStruct str = Profiler.ToStruct<ProcessInfoStruct>(ProcessProfiler.GetProcessInfo(UpdateFlags, Process.PID));
                        Process.Read(UpdateFlags, str);
                    }
                }
            });
        }
    }
}
