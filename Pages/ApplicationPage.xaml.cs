using ProcessManager.Profiling.Models.Process.Models;
using ProcessManager.Profiling.Models.Process;
using System.Collections.ObjectModel;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows;
using System.Drawing;

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

        public ObservableCollection<ProcessInfo> Processes = new ObservableCollection<ProcessInfo>();
        public HashSet<uint> Running = new HashSet<uint>();

        public ulong ProcessUpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.PROCESS_PIF_NAME | ProcessInfoFlags.PROCESS_PIF_IMAGE_NAME | ProcessInfoFlags.PROCESS_PIF_USER | ProcessInfoFlags.PROCESS_PIF_DESCRIPTION | ProcessInfoFlags.PROCESS_PIF_PRIORITY);

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
            IntPtr ptr = ProcessProfiler.GetAllProcessInfo(ProcessUpdateFlags, 0, 0, 0, 0, 0, 0, 0, out uint size);
            ProcessInfoStruct[] infos = Profiler.ToArray<ProcessInfoStruct>(ptr, size);

            for (int i = 0; i < size; i++)
            {
                ProcessInfo info = new ProcessInfo();
                info.Load(infos[i], ProcessUpdateFlags, 0, 0, 0, 0, 0, 0, 0);

                Processes.Add(info);
                Running.Add(info.PID);
            }

            ProcessProfiler.FreeProcessInfoArray(ptr, size);

            ApplicationList.ItemsSource = Processes;

            ProcessMonitor().Start();
        }

        internal Task ProcessMonitor()
        {
            return new Task(() =>
            {
                while (true)
                {
                    Task qTask = Task.Run(() =>
                    { 
                        IntPtr ptr = ProcessProfiler.GetAllProcessInfo(0, 0, 0, 0, 0, 0, 0, 0, out uint size);
                        ProcessInfoStruct[] infos = Profiler.ToArray<ProcessInfoStruct>(ptr, size);

                        HashSet<uint> runningPids = infos.Select(inf => inf.pid).ToHashSet();
                        HashSet<uint> existingPids = Processes.Select(p => p.PID).ToHashSet();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            // Add new processes
                            foreach (var processInfo in infos)
                            {
                                if (!existingPids.Contains(processInfo.pid))
                                {
                                    IntPtr newPtr = ProcessProfiler.GetProcessInfo(ProcessUpdateFlags, 0, 0, 0, 0, 0, 0, 0, processInfo.pid);
                                    ProcessInfoStruct newInfo = Profiler.ToStruct<ProcessInfoStruct>(newPtr);

                                    ProcessInfo info = new ProcessInfo();
                                    info.Load(newInfo, ProcessUpdateFlags, 0, 0, 0, 0, 0, 0, 0);

                                    Processes.Add(info);
                                    Running.Add(info.PID);
                                }
                            }

                            // Remove not running
                            for (int i = Processes.Count - 1; i >= 0; i--)
                            {
                                if (!runningPids.Contains(Processes[i].PID))
                                {
                                    Running.Remove(Processes[i].PID);
                                    Processes.RemoveAt(i);
                                }
                            }
                        });

                        ProcessProfiler.FreeProcessInfoArray(ptr, size);
                    });

                    Task.WaitAll(Task.Delay(2000), qTask);
                }
            });
        }
    }
}
