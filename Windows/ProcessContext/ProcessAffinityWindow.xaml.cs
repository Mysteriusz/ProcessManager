using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace ProcessManager.Windows.ProcessContext
{
    /// <summary>
    /// Interaction logic for ProcessAffinityWindow.xaml
    /// </summary>
    public partial class ProcessAffinityWindow : Window
    {
        public ObservableCollection<string> CoreList { get; private set; } = new ObservableCollection<string>();

        public ProcessAffinityWindow()
        {
            DataContext = this;
            InitializeComponent();
            GenerateCoreList();
        }

        private void GenerateCoreList()
        {
            for (int i = 0; i < 64; i++)
                Application.Current.Dispatcher.Invoke(() => CoreList.Add($"Core #{i}"));

            Application.Current.Dispatcher.Invoke(() => CorePanelList.GenerateOrder());
        }
    }
}
