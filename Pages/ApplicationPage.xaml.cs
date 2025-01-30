using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using ProcessManager.Profiling;
using System.Runtime.InteropServices;
using System;
using System.Collections.ObjectModel;
using ProcessManager.Profiling.Models;
using System.Xml.Linq;

namespace ProcessManager.Pages
{
    /// <summary>
    /// Interaction logic for ApplicationPage.xaml
    /// </summary>
    public partial class ApplicationPage : Page
    {
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

        ObservableCollection<ProcessInfo> Processes = new ObservableCollection<ProcessInfo>();

        public void InitializeApplicationList()
        {
            IntPtr ptr = ProcessProfiler.GetAllProcesses(out uint size);
            ProcessInfo[] processes = new ProcessInfo[size];
            for (int i = 0; i < size; i++)
            {
                IntPtr currentProcessPtr = ptr + (i * Marshal.SizeOf<ProcessInfoStruct>());
                ProcessInfoStruct processStruct = Marshal.PtrToStructure<ProcessInfoStruct>(currentProcessPtr);

                processes[i] = new ProcessInfo();
                processes[i].Name = Profiler.ToString(processStruct.name)!;
                processes[i].User = Profiler.ToString(processStruct.user)!;
                processes[i].Priority = Profiler.ToString(processStruct.priority)!;
                processes[i].ImageName = Profiler.ToString(processStruct.imageName)!;
                processes[i].PID = processStruct.pid;

                StartProcessDataCollector(processes[i]);
            }

            Processes = new ObservableCollection<ProcessInfo>(processes);
            ApplicationList.ItemsSource = Processes;
        }

        private void StartProcessDataCollector(ProcessInfo process)
        {
            Task.Run(async () =>
            {
                CpuProfiler.InitializeProcessCpuProfiler(process.PID);

                while (true)
                {
                    await Task.Delay(1500);
                    double usage = Profiler.ToStruct<double>(CpuProfiler.GetProcessCpuUsage(process.PID));
                    Dispatcher.Invoke(() => process.CpuUsage = Math.Round(usage, 2));
                }
            });
        }

        public void OpenProperties()
        {
            Debug.WriteLine("PROPERTIES");
        }
        //
        // ---------------------------------- EVENTS ----------------------------------
        //

        // ---------------------------------- THUMB ----------------------------------
        private void Thumb_ScrollBarDragDelta(object sender, DragDeltaEventArgs e)
        {
            ScrollBar bar = ((sender as Thumb)?.TemplatedParent as ScrollBar)!;
            double dragRatio = e.VerticalChange / bar.ActualHeight;

            ScrollViewer scroll = (bar.TemplatedParent as ScrollViewer)!;
            double newOffset = scroll.VerticalOffset + (dragRatio * scroll.ExtentHeight);
            scroll.ScrollToVerticalOffset(newOffset);
        }

        // ---------------------------------- ROW ----------------------------------
        private void ApplicationListRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenProperties();
        }
        private void ApplicationListRow_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                OpenProperties();
        }

        // ---------------------------------- LIST ----------------------------------
        private void ApplicationList_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            // Suppress Enter key
            if (e.Key == Key.Enter)
                e.Handled = true;
        }
    }
}
