using ProcessManager.Profiling.Models.Process;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;
using ProcessManager.Profiling;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Data;
using System.Diagnostics;
using ProcessManager.Windows;

namespace ProcessManager.Pages
{
    /// <summary>
    /// Interaction logic for ApplicationPage.xaml
    /// </summary>
    public partial class ApplicationPage : Page
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        private bool canSort = true;
        private int sortCooldownMs = 1000;

        ObservableCollection<ProcessInfo> Processes = new ObservableCollection<ProcessInfo>();

        //
        // ---------------------------------- CONSTRUCTORS ----------------------------------
        //

        public ApplicationPage()
        {
            InitializeComponent();
            InitializeApplicationList();
        }

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        internal void InitializeApplicationList()
        {
            ulong flags = (ulong)(ProcessInfoFlags.ProcessName | ProcessInfoFlags.ProcessImageName | ProcessInfoFlags.ProcessUser | ProcessInfoFlags.ProcessDescription | ProcessInfoFlags.ProcessPriority);

            IntPtr ptr = ProcessProfiler.GetAllProcessInfo(flags, out uint size);
            ProcessInfoStruct[] infos = Profiler.ToArray<ProcessInfoStruct>(ptr, size);

            for (int i = 0; i < size; i++)
            {
                ProcessInfo info = new ProcessInfo(infos[i]);
                Processes.Add(info);
            }

            ApplicationList.ItemsSource = Processes;
        }
        internal void OpenProperties(ProcessInfo info)
        {
            ulong flags = (ulong)(ProcessInfoFlags.ProcessFileVersion | ProcessInfoFlags.ProcessPEB | ProcessInfoFlags.ProcessParentName | ProcessInfoFlags.ProcessPPID | ProcessInfoFlags.ProcessCommandLine | ProcessInfoFlags.ProcessTimes | ProcessInfoFlags.ProcessArchitectureType);
            IntPtr ptr = ProcessProfiler.GetProcessInfo(flags, info.PID);
            info.Read(flags, Profiler.ToStruct<ProcessInfoStruct>(ptr));
            
            Debug.WriteLine(Profiler.ToString(ProcessProfiler.GetProcessDescription(info.PID)));

            ProcessPropertiesWindow processPropertiesWindow = new ProcessPropertiesWindow();
            processPropertiesWindow.DataContext = info;

            processPropertiesWindow.Show();
        }

        //
        // ---------------------------------- EVENTS ----------------------------------
        //

        // ---------------------------------- THUMB ----------------------------------
        private void Thumb_ScrollBarDragDelta(object sender, DragDeltaEventArgs e)
        {
            ScrollBar bar = ((sender as Thumb)?.TemplatedParent as ScrollBar)!;
            double dragRatio = e.VerticalChange / bar.ActualHeight;

            ScrollViewer scroll = (bar.TemplatedParent as ScrollViewer)!;
            double newOffset = scroll.VerticalOffset + (dragRatio * scroll.ExtentHeight);
            scroll.ScrollToVerticalOffset(newOffset);
        }

        // ---------------------------------- ROW ----------------------------------
        private void ApplicationListRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = (DataGridRow)sender;
            ProcessInfo processInfo = (ProcessInfo)row.DataContext;

            OpenProperties(processInfo);
        }
        private void ApplicationListRow_PreviewKeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                DataGridRow row = (DataGridRow)sender;
                int rowIndex = ApplicationList.ItemContainerGenerator.IndexFromContainer(row);

                OpenProperties(Processes[rowIndex]);
            }
        }

        // ---------------------------------- LIST ----------------------------------
        private void ApplicationList_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                e.Handled = true;
        }
        private void ApplicationList_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;

            if (!canSort)
                return;

            if (e.Column.SortDirection == ListSortDirection.Ascending)
                e.Column.SortDirection = ListSortDirection.Descending;
            else
                e.Column.SortDirection = ListSortDirection.Ascending;

            ListSortDirection sortDir = e.Column.SortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(ApplicationList.ItemsSource);

            if (collectionView == null)
                return;

            collectionView.SortDescriptions.Clear();
            collectionView.SortDescriptions.Add(new SortDescription(e.Column.SortMemberPath, sortDir));

            canSort = false;
            _ = SortCooldown();
        }
        private async Task SortCooldown()
        {
            await Task.Run(async () =>
            {
                await Task.Delay(sortCooldownMs);
                canSort = true;

                return;
            });
        }
    }
}
