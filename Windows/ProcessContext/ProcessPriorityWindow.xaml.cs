using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using System.Windows.Controls;
using ProcessManager.Actions;
using System.Windows;

namespace ProcessManager.Windows.ProcessContext
{
    /// <summary>
    /// Interaction logic for ProcessPriorityWindow.xaml
    /// </summary>
    public partial class ProcessPriorityWindow : Window
    {
        private ProcessInfo _info { get; }
        private uint _basePriority { get; } = 0;
        private uint _selectedPriority => AppDefinition.ProcessPriorities.FirstOrDefault(x => x.Value == PriorityBox.SelectionBoxItem.ToString()).Key;
        
        public ProcessPriorityWindow(ProcessInfo info)
        {
            InitializeComponent();

            _info = info;

            _basePriority = Profiler.ToUInt32(ProcessProfiler.GetProcessPriority(_info.PID)) ?? throw new Exception();
            PriorityBox.SelectedItem = PriorityBox.Items.Cast<ComboBoxItem>().FirstOrDefault(x => x.Content.ToString() == AppDefinition.ProcessPriorities[_basePriority]);
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessActions.SetPriority(_info.PID, _selectedPriority);
            _info.Priority = _selectedPriority;
            this.Close();
        }
    }
}
