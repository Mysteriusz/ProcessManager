using ProcessManager.Profiling.Models.Cpu;
using ProcessManager.Pages.SystemInfo;
using ProcessManager.Pages;
using System.Windows;

namespace ProcessManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Row 1
        private ApplicationPage? _applicationPage;

        // Row 2
        private CpuInfoPage? _cpuPage;
        private CpuInfo? _infoContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainPageFrame_Loaded(object sender, RoutedEventArgs e)
        {
            _applicationPage = new();
            MainPageFrame.Navigate(_applicationPage);
        }
        private void SysInfoPageFrame_Loaded(object sender, RoutedEventArgs e)
        {
            _cpuPage = new CpuInfoPage();
            _infoContext = new CpuInfo();

            _cpuPage.DataContext = _infoContext;
            SysInfoPageFrame.Navigate(_cpuPage);
        }
    }
}