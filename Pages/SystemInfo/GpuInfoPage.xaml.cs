using ProcessManager.Profiling.Models.Gpu.Models;
using ProcessManager.Profiling.Models.Gpu;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Diagnostics;

namespace ProcessManager.Pages.SystemInfo
{
    /// <summary>
    /// Interaction logic for GpuInfoPage.xaml
    /// </summary>
    public partial class GpuInfoPage : Page
    {
        public ulong GpuInfoConstFlags { get; set; } = (ulong)(GpuInfoFlags.GPU_GIF_DX_SUPPORT | GpuInfoFlags.GPU_GIF_PHYSICAL_INFO | GpuInfoFlags.GPU_GIF_MODEL_INFO | GpuInfoFlags.GPU_GIF_VRAM_SIZE);
        public ulong GpuPhysicalInfoConstFlags { get; set; } = (ulong)(GpuPhysicalInfoFlags.GPU_PIF_ALL);
        public ulong GpuModelInfoConstFlags { get; set; } = (ulong)(GpuModelInfoFlags.GPU_MIF_ALL);
        public ulong GpuResolutionInfoConstFlags { get; set; } = 0;
        public ulong GpuUtilizationInfoConstFlags { get; set; } = 0;

        public ulong GpuInfoUpdateFlags { get; set; } = (ulong)(GpuInfoFlags.GPU_GIF_UTILIZATION_INFO | GpuInfoFlags.GPU_GIF_MIN_RES_INFO | GpuInfoFlags.GPU_GIF_MAX_RES_INFO | GpuInfoFlags.GPU_GIF_VRAM_USAGE);
        public ulong GpuPhysicalInfoUpdateFlags { get; set; } = 0;
        public ulong GpuModelInfoUpdateFlags { get; set; } = 0;
        public ulong GpuResolutionInfoUpdateFlags { get; set; } = (ulong)(GpuResolutionInfoFlags.GPU_RIF_ALL);
        public ulong GpuUtilizationInfoUpdateFlags { get; set; } = (ulong)(GpuUtilizationInfoFlags.GPU_UIF_ALL);

        public int UpdateDelay { get; set; } = 1000;
        public CancellationTokenSource? UpdateCancellation { get; set; }

        public GpuInfo? GpuInfo { get; set; }

        public GpuInfoPage()
        {
            InitializeComponent();
        }

        public void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            GpuInfo = DataContext as GpuInfo;
            UpdateCancellation = new CancellationTokenSource();

            if (GpuInfo == null)
                throw new Exception();

            IntPtr ptr = GpuProfiler.GetGpuInfo(GpuInfoConstFlags, GpuModelInfoConstFlags, GpuUtilizationInfoConstFlags, GpuPhysicalInfoConstFlags, GpuResolutionInfoConstFlags);
            GpuInfoStruct info = Profiler.ToStruct<GpuInfoStruct>(ptr);
            GpuInfo.Load(info, GpuInfoConstFlags, GpuModelInfoConstFlags, GpuUtilizationInfoConstFlags, GpuPhysicalInfoConstFlags, GpuResolutionInfoConstFlags);
            GpuProfiler.FreeGpuInfo(ptr);

            UpdateTask().Start();
        }
        public void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            GpuInfo?.Unload(GpuInfoConstFlags, GpuModelInfoConstFlags, GpuUtilizationInfoConstFlags, GpuPhysicalInfoConstFlags, GpuResolutionInfoConstFlags);

            UpdateCancellation?.Cancel();
            UpdateCancellation?.Dispose();

            UpdateCancellation = null;

            GC.Collect();
        }

        public Task UpdateTask()
        {
            return new Task(async () =>
            {
                if (UpdateCancellation == null || GpuInfo == null)
                    return;

                while (UpdateCancellation != null && !UpdateCancellation.IsCancellationRequested)
                {
                    try
                    {
                        IntPtr ptr = GpuProfiler.GetGpuInfo(GpuInfoUpdateFlags, GpuModelInfoUpdateFlags, GpuUtilizationInfoUpdateFlags, GpuPhysicalInfoUpdateFlags, GpuResolutionInfoUpdateFlags);
                        GpuInfoStruct info = Profiler.ToStruct<GpuInfoStruct>(ptr);
                        GpuInfo.Load(info, GpuInfoUpdateFlags, GpuModelInfoUpdateFlags, GpuUtilizationInfoUpdateFlags, GpuPhysicalInfoUpdateFlags, GpuResolutionInfoUpdateFlags);
                        GpuProfiler.FreeGpuInfo(ptr);

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
