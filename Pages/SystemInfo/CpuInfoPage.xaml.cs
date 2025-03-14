﻿using ProcessManager.Profiling.Models.Cpu.Models;
using ProcessManager.Profiling.Models.Cpu;
using ProcessManager.Profiling;
using System.Windows.Controls;

namespace ProcessManager.Pages.SystemInfo
{
    /// <summary>
    /// Interaction logic for CpuInfoPage.xaml
    /// </summary>
    public partial class CpuInfoPage : Page
    {
        public ulong CpuInfoConstFlags { get; set; } = (ulong)(CpuInfoFlags.CPU_CIF_SYS_INFO | CpuInfoFlags.CPU_CIF_MODEL_INFO | CpuInfoFlags.CPU_CIF_CACHE_INFO | CpuInfoFlags.CPU_CIF_BASE_FREQ | CpuInfoFlags.CPU_CIF_MAX_FREQ | CpuInfoFlags.CPU_CIF_VIRTUALIZATION | CpuInfoFlags.CPU_CIF_HYPER_THREADING);
        public ulong SystemInfoConstFlags { get; set; } = (ulong)(CpuSystemInfoFlags.CPU_SIF_ALL);
        public ulong ModelInfoConstFlags { get; set; } = (ulong)(CpuModelInfoFlags.CPU_MIF_ALL);
        public ulong TimesInfoConstFlags { get; set; } = 0;
        public ulong CacheInfoConstFlags { get; set; } = (ulong)(CpuCacheInfoFlags.CPU_HIF_ALL);

        public ulong CpuInfoUpdateFlags { get; set; } = (ulong)(CpuInfoFlags.CPU_CIF_TIMES_INFO | CpuInfoFlags.CPU_CIF_HANDLES | CpuInfoFlags.CPU_CIF_THREADS);
        public ulong SystemInfoUpdateFlags { get; set; } = 0;
        public ulong ModelInfoUpdateFlags { get; set; } = 0;
        public ulong TimesInfoUpdateFlags { get; set; } = (ulong)(CpuTimesInfoFlags.CPU_TIF_ALL);
        public ulong CacheInfoUpdateFlags { get; set; } = 0;

        public int UpdateDelay { get; set; } = 1000;
        public CancellationTokenSource? UpdateCancellation { get; set; }

        public CpuInfo? CpuInfo { get; set; }

        public CpuInfoPage()
        {
            InitializeComponent();
        }

        public void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            CpuInfo = DataContext as CpuInfo;
            UpdateCancellation = new CancellationTokenSource();

            if (CpuInfo == null)
                throw new Exception();

            IntPtr ptr = CpuProfiler.GetCpuInfo(CpuInfoConstFlags, SystemInfoConstFlags, ModelInfoConstFlags, TimesInfoConstFlags, CacheInfoConstFlags);
            CpuInfoStruct info = Profiler.ToStruct<CpuInfoStruct>(ptr);
            CpuInfo.Load(info, CpuInfoConstFlags, SystemInfoConstFlags, ModelInfoConstFlags, TimesInfoConstFlags, CacheInfoConstFlags);
            CpuProfiler.FreeCpuInfo(ptr);


            UpdateTask().Start();
        }
        public void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            CpuInfo?.Unload(CpuInfoUpdateFlags, SystemInfoUpdateFlags, ModelInfoUpdateFlags, TimesInfoUpdateFlags, CacheInfoUpdateFlags);

            UpdateCancellation?.Cancel();
            UpdateCancellation?.Dispose();

            UpdateCancellation = null;

            GC.Collect();
        }

        public Task UpdateTask()
        {
            return new Task(async () =>
            {
                if (UpdateCancellation == null || CpuInfo == null)
                    return;

                while (UpdateCancellation != null && !UpdateCancellation.IsCancellationRequested)
                {
                    try
                    {
                        IntPtr usg1 = CpuProfiler.GetCpuUsage();
                        await Task.Delay(UpdateDelay / 3);
                        IntPtr usg2 = CpuProfiler.GetCpuUsage();
                        await Task.Delay(UpdateDelay / 3);
                        IntPtr usg3 = CpuProfiler.GetCpuUsage();

                        double d1 = Profiler.ToDouble(usg1) ?? 0;
                        double d2 = Profiler.ToDouble(usg2) ?? 0;
                        double d3 = Profiler.ToDouble(usg3) ?? 0;

                        if (CpuInfo != null)
                            CpuInfo.Usage = (d1 + d2 + d3) / 3;
                        else
                            break;

                        IntPtr ptr = CpuProfiler.GetCpuInfo(CpuInfoUpdateFlags, SystemInfoUpdateFlags, ModelInfoUpdateFlags, TimesInfoUpdateFlags, CacheInfoUpdateFlags);
                        CpuInfoStruct info = Profiler.ToStruct<CpuInfoStruct>(ptr);

                        if (CpuInfo != null)
                            CpuInfo.Load(info, CpuInfoUpdateFlags, SystemInfoUpdateFlags, ModelInfoUpdateFlags, TimesInfoUpdateFlags, CacheInfoUpdateFlags);
                        else
                            break;
                        
                        CpuProfiler.FreeCpuInfo(ptr);

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
