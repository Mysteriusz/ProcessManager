using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using ProcessManager.Profiling;
using System.Collections.ObjectModel;
using ProcessManager.Profiling.Models.Process;
using System.ComponentModel;
using System.Data.Common;
using System.Windows.Data;
using System.Globalization;

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

        ObservableCollection<ProcessInfo> Processes = new ObservableCollection<ProcessInfo>();

        public void InitializeApplicationList()
        {
            ProcessProfiler.TryGetAllProcesses(out ProcessInfoStruct[]? structs);
            foreach (ProcessInfoStruct str in structs!)
            {
                ProcessInfo info = new ProcessInfo()
                {
                    Name = Profiler.ToString(str.name) ?? "",
                    ImageName = Profiler.ToString(str.imageName) ?? "",
                    User = Profiler.ToString(str.user) ?? "",
                    Priority = Profiler.ToString(str.priority) ?? "",
                    PID = str.pid,
                };

                ProcessProfiler.StartProcessDataCollector(info, ApplicationList.Dispatcher);

                Processes.Add(info);
            }

            ApplicationList.ItemsSource = Processes;
        }

        public void OpenProperties()
        {
            Debug.WriteLine("PROPERTIES");
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
            OpenProperties();
        }
        private void ApplicationListRow_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                OpenProperties();
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
