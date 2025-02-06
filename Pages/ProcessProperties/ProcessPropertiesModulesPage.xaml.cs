using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesModulesPage.xaml
    /// </summary>
    public partial class ProcessPropertiesModulesPage : Page
    {
        public ulong UpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.ProcessModulesInfo);
        public int UpdateDelay { get; set; } = 10000;
        public ProcessInfo? Process { get; set; }
        public CancellationTokenSource? Token { get; set; }

        public ProcessPropertiesModulesPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Process = DataContext as ProcessInfo;
            Token = new CancellationTokenSource();

            if (Process == null)
                throw new Exception();

            UpdateThread().Start();
        }
        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Token!.Cancel();
        }

        private Thread UpdateThread()
        {
            return new Thread(async () =>
            {
                if (Token == null || Process == null)
                    return;

                object threadLock = new object();

                while (!Token.IsCancellationRequested)
                {
                    lock (threadLock)
                    {
                        IntPtr ptr = ProcessProfiler.GetProcessInfo(UpdateFlags, Process.PID);

                        ProcessInfoStruct info = Profiler.ToStruct<ProcessInfoStruct>(ptr);
                        Process.Read(UpdateFlags, info);
                        ProcessProfiler.FreeProcessInfo(ptr);
                    }

                    await Task.Delay(UpdateDelay);
                }
            });
        }
    }
}
