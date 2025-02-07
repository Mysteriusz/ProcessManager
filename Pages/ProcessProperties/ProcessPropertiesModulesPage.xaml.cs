﻿using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesModulesPage.xaml
    /// </summary>
    public partial class ProcessPropertiesModulesPage : Page
    {
        public ulong UpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.ProcessModulesInfo);
        public ulong ModuleUpdateFlags { get; set; } = (ulong)(ModuleInfoFlags.ModuleName | ModuleInfoFlags.ModulePath | ModuleInfoFlags.ModuleDescription | ModuleInfoFlags.ModuleAddress | ModuleInfoFlags.ModuleSize);
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

            IntPtr ptr = ProcessProfiler.GetProcessInfo(UpdateFlags, ModuleUpdateFlags, Process.PID);
            ProcessInfoStruct info = Profiler.ToStruct<ProcessInfoStruct>(ptr);
            Process.Read(UpdateFlags, ModuleUpdateFlags, info);
            ProcessProfiler.FreeProcessInfo(ptr);
        }
        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Process?.Unload(UpdateFlags, ModuleUpdateFlags);

            Token?.Cancel();
            Token?.Dispose();

            UpdateFlags = 0;
            ModuleUpdateFlags = 0;
            UpdateDelay = 0;

            Token = null;
            Process = null;

            GC.Collect();
        }
    }
}
