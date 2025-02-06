using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling;
using ProcessManager.Windows;

namespace ProcessManager.WPFHelpers
{
    public partial class ApplicationDataGrid 
    {
        public ApplicationDataGrid()
        {
            InitializeComponent();
        }

        // ---------------------------------- THUMB ----------------------------------
        public void Thumb_ScrollBarDragDelta(object sender, DragDeltaEventArgs e)
        {
            ScrollBar bar = ((sender as Thumb)?.TemplatedParent as ScrollBar)!;
            double dragRatio = e.VerticalChange / bar.ActualHeight;

            ScrollViewer scroll = (bar.TemplatedParent as ScrollViewer)!;
            double newOffset = scroll.VerticalOffset + (dragRatio * scroll.ExtentHeight);
            scroll.ScrollToVerticalOffset(newOffset);
        }

        // ---------------------------------- ROW ----------------------------------
        public void ApplicationListRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow ?? throw new Exception();

            if (row.DataContext is ProcessInfo info)
                OpenProcessProperties(info);

            e.Handled = true;
        }
        public void ApplicationListRow_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DataGridRow row = sender as DataGridRow ?? throw new Exception();

                if (row.DataContext is ProcessInfo info)
                    OpenProcessProperties(info);
            }

            e.Handled = true;
        }

        // ---------------------------------- LIST ----------------------------------
        public void ApplicationList_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                e.Handled = true;
        }

        internal void OpenProcessProperties(ProcessInfo info)
        {
            ProcessPropertiesWindow processPropertiesWindow = new ProcessPropertiesWindow();
            processPropertiesWindow.DataContext = info;

            processPropertiesWindow.Show();
        }
    }
}
