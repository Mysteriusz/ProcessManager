﻿using ProcessManager.Pages.ProcessProperties.Models;
using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using ProcessManager.Profiling.Models.Process.Models;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesGeneralPage.xaml
    /// </summary>
    public partial class ProcessPropertiesGeneralPage : Page, IProcessPropertiesPage
    {
        //
        //---------------------------------- PROPERTIES ----------------------------------
        //

        public ulong ProcessInfoUpdateFlags { get; set; } = (ulong)(ProcessInfoFlags.PROCESS_PIF_FILE_VERSION | ProcessInfoFlags.PROCESS_PIF_PEB | ProcessInfoFlags.PROCESS_PIF_PARENT_NAME | ProcessInfoFlags.PROCESS_PIF_PPID | ProcessInfoFlags.PROCESS_PIF_COMMAND_LINE | ProcessInfoFlags.PROCESS_PIF_TIMES | ProcessInfoFlags.PROCESS_PIF_ARCHITECTURE_TYPE);
        public ulong ThreadInfoUpdateFlags { get; set; } = 0;
        public ulong HandleInfoUpdateFlags { get; set; } = 0;
        public ulong ModuleInfoUpdateFlags { get; set; } = 0;
        public ulong IOInfoUpdateFlags { get; set; } = 0;
        public ulong MemoryInfoUpdateFlags { get; set; } = 0;
        public ulong TimesInfoUpdateFlags { get; set; } = (ulong)(ProcessTimesInfoFlags.PROCESS_TIF_CREATION_TIME);
        public ulong CpuInfoUpdateFlags { get; set; } = 0;

        public int UpdateDelay { get; set; } = 1000;
        public CancellationTokenSource? UpdateCancellation { get; set; }

        public ProcessInfo? ProcessInfo { get; set; }

        //
        //---------------------------------- CONSTRUCTORS ----------------------------------
        //

        public ProcessPropertiesGeneralPage()
        {
            InitializeComponent();
        }

        //
        //---------------------------------- EVENTS ----------------------------------
        //

        public void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ProcessInfo = DataContext as ProcessInfo;
            UpdateCancellation = new CancellationTokenSource();

            if (ProcessInfo == null)
                throw new Exception();
            
            IntPtr ptr = ProcessProfiler.GetProcessInfo(ProcessInfoUpdateFlags, ModuleInfoUpdateFlags, HandleInfoUpdateFlags, ThreadInfoUpdateFlags, TimesInfoUpdateFlags, MemoryInfoUpdateFlags, CpuInfoUpdateFlags, IOInfoUpdateFlags, ProcessInfo.PID);
            ProcessInfoStruct info = Profiler.ToStruct<ProcessInfoStruct>(ptr);
            ProcessInfo.Load(info, ProcessInfoUpdateFlags, ModuleInfoUpdateFlags, HandleInfoUpdateFlags, ThreadInfoUpdateFlags, TimesInfoUpdateFlags, MemoryInfoUpdateFlags, CpuInfoUpdateFlags, IOInfoUpdateFlags);

            ProcessProfiler.FreeProcessInfo(ptr);
        }
        public void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ProcessInfo?.Unload(ProcessInfoUpdateFlags, ModuleInfoUpdateFlags, HandleInfoUpdateFlags, ThreadInfoUpdateFlags, TimesInfoUpdateFlags, MemoryInfoUpdateFlags, CpuInfoUpdateFlags, IOInfoUpdateFlags);

            UpdateCancellation?.Cancel();
            UpdateCancellation?.Dispose();

            UpdateCancellation = null;
            ProcessInfo = null;

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
