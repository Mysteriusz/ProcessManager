using ProcessManager.Profiling.Models.Process;
using System.Collections.ObjectModel;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows;
using ProcessManager.Actions;

namespace ProcessManager.Windows.ProcessContext
{
    /// <summary>
    /// Interaction logic for ProcessAffinityWindow.xaml
    /// </summary>
    public partial class ProcessAffinityWindow : Window
    {
        private ProcessInfo _info { get; }
        public ObservableCollection<string> CoreList { get; private set; } = new ObservableCollection<string>();

        public ProcessAffinityWindow(ProcessInfo info)
        {
            _info = info;

            DataContext = this;
            InitializeComponent();
            GenerateCoreList();
        }

        private void GenerateCoreList()
        {
            bool[] affinityBitMask = GetBits(Profiler.ToUInt64(ProcessProfiler.GetProcessAffinity(_info.PID)) ?? 0);

            for (int i = 0; i < 64; i++)
            {
                if (affinityBitMask[i] == true)
                    CorePanelList.Constraints.Add(i, new KeyValuePair<DependencyProperty, object>(CheckBox.IsCheckedProperty, true));

                CoreList.Add($"Core #{i}");
            }

            CorePanelList.GenerateOrder();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ulong newAffinity = 0;

            for (int i = CorePanelList.Elements.Count - 1; i >= 0; i--)
            {
                if (CorePanelList.Elements[i] is CheckBox elem)
                    newAffinity = (newAffinity << 1) | (elem.IsChecked == false ? 0UL : 1);
            }

            ProcessActions.SetAffinity(_info.PID, newAffinity);

            this.Close();
        }

        private bool[] GetBits(ulong value)
        {
            bool[] bits = new bool[64];

            for (int i = 0; i < 64; i++)
            {
                bits[i] = ((value >> i) & 1) == 0 ? false : true;
            }

            return bits;
        }
    }
}
