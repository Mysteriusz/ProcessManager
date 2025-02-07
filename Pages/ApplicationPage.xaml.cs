using ProcessManager.Profiling.Models.Process;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;
using ProcessManager.Profiling;
using System.Windows.Controls;
using ProcessManager.Windows;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Data;
using System.Diagnostics;

namespace ProcessManager.Pages
{
    /// <summary>
    /// Interaction logic for ApplicationPage.xaml
    /// </summary>
    public partial class ApplicationPage : Page
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        ObservableCollection<ProcessInfo> Processes = new ObservableCollection<ProcessInfo>();

        //
        // ---------------------------------- CONSTRUCTORS ----------------------------------
        //

        public ApplicationPage()
        {
            InitializeComponent();
            InitializeApplicationList();
        }

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        internal void InitializeApplicationList()
        {
            //Thread threa = new Thread(async () =>
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(1000);

            //        IntPtr ptr = ProcessProfiler.GetProcessAllModuleInfo(1880, out uint size);
            //        ProcessModuleInfo[] infos = Process.
            //    }
            //});

            ulong flags = (ulong)(ProcessInfoFlags.ProcessName | ProcessInfoFlags.ProcessImageName | ProcessInfoFlags.ProcessUser | ProcessInfoFlags.ProcessDescription | ProcessInfoFlags.ProcessPriority);

            IntPtr ptr = ProcessProfiler.GetAllProcessInfo(flags, 0, out uint size);
            ProcessInfoStruct[] infos = Profiler.ToArray<ProcessInfoStruct>(ptr, size);

            for (int i = 0; i < size; i++)
            {
                ProcessInfo info = new ProcessInfo(infos[i]);
                Processes.Add(info);
            }

            ApplicationList.ItemsSource = Processes;
        }
    }
}
