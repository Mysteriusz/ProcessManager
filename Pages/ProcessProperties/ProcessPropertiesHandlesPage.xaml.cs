using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesHandlesPage.xaml
    /// </summary>
    public partial class ProcessPropertiesHandlesPage : Page
    {
        public ulong UpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.ProcessHandlesInfo);
        public ulong HandleFlags { get; set; } = (ulong)(HandleInfoFlags.HandleName | HandleInfoFlags.HandleType | HandleInfoFlags.HandleAddress);
        public int UpdateDelay { get; set; } = 1000;
        public ProcessInfo? Process { get; set; }
        public CancellationTokenSource? Token { get; set; }

        public ProcessPropertiesHandlesPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Process = DataContext as ProcessInfo;
            Token = new CancellationTokenSource();

            if (Process == null)
                throw new Exception();

            IntPtr ptr = ProcessProfiler.GetProcessInfo(UpdateFlags, 0, HandleFlags, Process.PID);
            ProcessInfoStruct info = Profiler.ToStruct<ProcessInfoStruct>(ptr);
            Process.Read(UpdateFlags, 0, HandleFlags, info);
            ProcessProfiler.FreeProcessInfo(ptr);
        }
        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Process?.Unload(UpdateFlags, 0, HandleFlags);

            Token?.Cancel();
            Token?.Dispose();

            UpdateFlags = 0;
            HandleFlags = 0;
            UpdateDelay = 0;

            Token = null;
            Process = null;

            GC.Collect();
        }
    }
}
