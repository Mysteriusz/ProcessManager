using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesGeneralPage.xaml
    /// </summary>
    public partial class ProcessPropertiesGeneralPage : Page
    {
        public ulong UpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.ProcessFileVersion | ProcessInfoFlags.ProcessPEB | ProcessInfoFlags.ProcessParentName | ProcessInfoFlags.ProcessPPID | ProcessInfoFlags.ProcessCommandLine | ProcessInfoFlags.ProcessTimes | ProcessInfoFlags.ProcessArchitectureType);
        public int UpdateDelay { get; set; } = 1000;
        public ProcessInfo? Process { get; set; }
        public CancellationTokenSource? Token { get; set; }

        public ProcessPropertiesGeneralPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Process = DataContext as ProcessInfo;
            Token = new CancellationTokenSource();

            if (Process == null)
                throw new Exception();
            
            IntPtr ptr = ProcessProfiler.GetProcessInfo(UpdateFlags, 0, 0, 0, Process.PID);
            ProcessInfoStruct info = Profiler.ToStruct<ProcessInfoStruct>(ptr);
            Process.Read(info, processFlags: UpdateFlags);

            ProcessProfiler.FreeProcessInfo(ptr);
        }
        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Process?.Unload(processFlags: UpdateFlags);

            Token?.Cancel();
            Token?.Dispose();

            Token = null;
            Process = null;

            GC.Collect();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Skip not arrow keys
            if (!(e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down))
                e.Handled = true;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Border? button = sender as Border;
                Grid? grid = button!.Parent as Grid;
                Border? textBorder = grid!.FindName("TextBorder") as Border;
                TextBox? textBox = textBorder!.FindName("TextBlock") as TextBox;

                Clipboard.SetText(textBox!.Text);
            }
        }
    }
}
