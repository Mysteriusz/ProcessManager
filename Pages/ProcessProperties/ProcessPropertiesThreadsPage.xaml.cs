using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Windows;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesThreadsPage.xaml
    /// </summary>
    public partial class ProcessPropertiesThreadsPage : Page
    {
        public ulong UpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.ProcessThreadsInfo);
        public ulong ThreadUpdateFlags { get; set; } = (ulong)(ThreadInfoFlags.ThreadStartAddress | ThreadInfoFlags.ThreadTid | ThreadInfoFlags.ThreadPriority | ThreadInfoFlags.ThreadCycles);
        public int UpdateDelay { get; set; } = 5000;
        public ProcessInfo? Process { get; set; }
        public CancellationTokenSource? Token { get; set; }

        public ProcessPropertiesThreadsPage()
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
            Process?.Unload(processFlags:UpdateFlags, threadFlags: ThreadUpdateFlags);

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
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        IntPtr ptr = ProcessProfiler.GetProcessInfo(UpdateFlags, 0, 0, ThreadUpdateFlags, Process.PID);
                        ProcessInfoStruct str = Profiler.ToStruct<ProcessInfoStruct>(ptr);
                        Process.Read(str, processFlags: UpdateFlags, threadFlags: ThreadUpdateFlags);
                        ProcessProfiler.FreeProcessInfo(ptr);
                    });

                    await Task.Delay(UpdateDelay);
                }
            });
        }
    }
}
