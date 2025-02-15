using System.Windows.Controls;

namespace ProcessManager.Pages
{
    /// <summary>
    /// Interaction logic for InfoBarPage.xaml
    /// </summary>
    public partial class InfoBarPage : Page
    {
        public double CpuUsage { get; set; }
        public ulong MemUsage { get; set; }
        public uint ProcessCount { get; set; }

        public InfoBarPage()
        {
            InitializeComponent();
        }
    }
}
