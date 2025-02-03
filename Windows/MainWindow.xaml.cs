using ProcessManager.Profiling;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace ProcessManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Profiler.EnableDebugPrivilages();
        }
    }
}