using ProcessManager.Profiling.Models.Cpu;
using ProcessManager.Profiling.Models.Gpu;
using ProcessManager.Pages.SystemInfo;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using ProcessManager.Profiling.Models.Ram;

namespace ProcessManager.Pages
{
    /// <summary>
    /// Interaction logic for SystemInfoPage.xaml
    /// </summary>
    public partial class SystemInfoPage : Page
    {

        private CpuInfoPage? _cpuPage = new CpuInfoPage();
        private CpuInfo? _cpuInfoContext = new();

        private GpuInfoPage? _gpuPage = new GpuInfoPage();
        private GpuInfo? _gpuInfoContext = new();

        private RamInfoPage? _ramPage = new RamInfoPage();
        private RamInfo? _ramInfoContext = new();
        
        private int _switchDelay = 1000;
        private bool _canSwitch = true;

        public SystemInfoPage()
        {
            InitializeComponent();
        }

        private void SystemInfoPageFrame_Loaded(object sender, RoutedEventArgs e)
        {
            _cpuPage.DataContext = _cpuInfoContext;
            SystemInfoPageFrame.Navigate(_cpuPage);
        }

        private async void SystemInfoPageCpuButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Border border && e.ChangedButton == MouseButton.Left)
            {
                if (!_canSwitch)
                    return;

                _canSwitch = false;

                switch (border.Tag)
                {
                    case "CPU":
                        _cpuPage.DataContext = _cpuInfoContext;
                        SystemInfoPageFrame.Navigate(_cpuPage);
                        break;
                    case "GPU":
                        _gpuPage.DataContext = _gpuInfoContext;
                        SystemInfoPageFrame.Navigate(_gpuPage);
                        break;
                    case "RAM":
                        _ramPage.DataContext = _ramInfoContext;
                        SystemInfoPageFrame.Navigate(_ramPage);
                        break;
                }

                await SwitchDelayTask();
            }
        }

        private async Task SwitchDelayTask()
        {
            await Task.Delay(_switchDelay);
            _canSwitch = true;
        }
    }
}
