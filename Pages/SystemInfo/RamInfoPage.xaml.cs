using ProcessManager.Profiling.Models.Ram.Models;
using ProcessManager.Profiling.Models.Ram;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Diagnostics;

namespace ProcessManager.Pages.SystemInfo
{
    /// <summary>
    /// Interaction logic for RamInfoPage.xaml
    /// </summary>
    public partial class RamInfoPage : Page
    {
        public ulong RamInfoConstFlags { get; set; } = (ulong)(RamInfoFlags.RAM_RIF_ALL);
        public ulong RamBlockInfoConstFlags { get; set; } = (ulong)(RamBlockInfoFlags.RAM_BIF_ALL);
        public ulong RamUtilizationInfoConstFlags { get; set; } = 0;

        public ulong RamInfoUpdateFlags { get; set; } = (ulong)(RamInfoFlags.RAM_RIF_UTILIZATION_INFO);
        public ulong RamBlockInfoUpdateFlags { get; set; } = 0;
        public ulong RamUtilizationInfoUpdateFlags { get; set; } = (ulong)(RamUtilizationInfoFlags.RAM_UIF_ALL);

        public int UpdateDelay { get; set; } = 1000;
        public CancellationTokenSource? UpdateCancellation { get; set; }

        public RamInfo? RamInfo { get; set; }


        public RamInfoPage()
        {
            InitializeComponent();
        }

        public void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            RamInfo = DataContext as RamInfo;
            UpdateCancellation = new CancellationTokenSource();

            if (RamInfo == null)
                throw new Exception();

            IntPtr ptr = RamProfiler.GetRamInfo(RamInfoConstFlags, RamUtilizationInfoConstFlags, RamBlockInfoConstFlags);
            RamInfoStruct info = Profiler.ToStruct<RamInfoStruct>(ptr);
            RamInfo.Load(info, RamInfoConstFlags, RamUtilizationInfoConstFlags, RamBlockInfoConstFlags);
            RamProfiler.FreeRamInfo(ptr);

            UpdateTask().Start();
        }
        public void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            RamInfo?.Unload(RamInfoConstFlags, RamUtilizationInfoConstFlags, RamBlockInfoConstFlags);

            UpdateCancellation?.Cancel();
            UpdateCancellation?.Dispose();

            UpdateCancellation = null;

            GC.Collect();
        }

        public Task UpdateTask()
        {
            return new Task(async () =>
            {
                if (UpdateCancellation == null || RamInfo == null)
                    return;

                while (UpdateCancellation != null && !UpdateCancellation.IsCancellationRequested)
                {
                    try
                    {
                        IntPtr ptr = RamProfiler.GetRamInfo(RamInfoUpdateFlags, RamUtilizationInfoUpdateFlags, RamBlockInfoUpdateFlags);
                        RamInfoStruct info = Profiler.ToStruct<RamInfoStruct>(ptr);
                        RamInfo.Load(info, RamInfoUpdateFlags, RamUtilizationInfoUpdateFlags, RamBlockInfoUpdateFlags);
                        RamProfiler.FreeRamInfo(ptr);

                        Debug.WriteLine(info.utilizationInfo.availablePhysicalMemory);

                        await Task.Delay(UpdateDelay);

                        GC.Collect(0);
                    }
                    catch
                    {
                        break;
                    }
                }
            });
        }
    }
}
