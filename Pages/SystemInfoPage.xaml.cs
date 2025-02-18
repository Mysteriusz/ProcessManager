using System.Windows.Controls;
using System.Windows;
using ProcessManager.Pages.SystemInfo;
using ProcessManager.Profiling.Models.Cpu;
using ProcessManager.Profiling.Models.Gpu;
using System.Windows.Input;

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

        public SystemInfoPage()
        {
            InitializeComponent();
        }

        private void SystemInfoPageFrame_Loaded(object sender, RoutedEventArgs e)
        {
            _cpuPage.DataContext = _cpuInfoContext;
            SystemInfoPageFrame.Navigate(_cpuPage);
        }

        private void SystemInfoPageCpuButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Border border && e.ChangedButton == MouseButton.Left)
            {
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
                }
            }
        }
    }
}
