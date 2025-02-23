using ProcessManager.Profiling.Models.Process;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using ProcessManager.Windows;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using ProcessManager.Actions;
using System.Security.Cryptography;

namespace ProcessManager.WPFHelpers
{
    public partial class ApplicationDataGrid 
    {
        private ContextMenu? processContextMenu;
        private ProcessInfo? currentProcessInfo;

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
        public void ApplicationListRow_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow ?? throw new Exception();

            if (row.DataContext is ProcessInfo info)
                OpenProcessContextMenu(info);

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

        internal void OpenProcessContextMenu(ProcessInfo info)
        {
            if (processContextMenu == null)
            {
                processContextMenu = new();

                processContextMenu.Style = ContextMenuStyle();
                processContextMenu.ItemsPanel = ContextItemMenuStyle();

                foreach (object b in CreateProcessContextMenu())
                    processContextMenu.Items.Add(b);
            }

            currentProcessInfo = info;

            processContextMenu.IsOpen = true;
        }
        internal void OpenProcessProperties(ProcessInfo info)
        {
            ProcessPropertiesWindow processPropertiesWindow = new ProcessPropertiesWindow();
            processPropertiesWindow.DataContext = info;

            processPropertiesWindow.Show();
        }

        // ---------------------------------- CONTEXT MENU ----------------------------------

        private object[] CreateProcessContextMenu()
        {
            Separator separator = new Separator(); 
            
            MenuItem killProcessButton = new MenuItem() { Header = "Kill Process", Foreground = AppDefinition.LightTextColor };
            killProcessButton.Click += (s, a) => ProcessActions.KillProcess(GetCurrentProcessPID());

            MenuItem suspendProcessButton = new MenuItem() { Header = "Suspend Process", Foreground = AppDefinition.LightTextColor };
            suspendProcessButton.Click += (s, a) => ProcessActions.SuspendProcess(GetCurrentProcessPID());

            MenuItem resumeProcessButton = new MenuItem() { Header = "Resume Process", Foreground = AppDefinition.LightTextColor };
            resumeProcessButton.Click += (s, a) => ProcessActions.ResumeProcess(GetCurrentProcessPID());

            MenuItem setAffinityButton = new MenuItem() { Header = "Set Affinity" , Foreground = AppDefinition.LightTextColor }; 
            MenuItem setPriorityButton = new MenuItem() { Header = "Set Priority" , Foreground = AppDefinition.LightTextColor };

            return [killProcessButton, suspendProcessButton, resumeProcessButton, setAffinityButton, setPriorityButton];
        }
        private uint GetCurrentProcessPID()
        {
            return currentProcessInfo == null ? uint.MaxValue : currentProcessInfo.PID;
        }

        private Style ContextMenuStyle()
        {
            Style style = new Style(typeof(ContextMenu));

            ControlTemplate template = new ControlTemplate(typeof(ContextMenu));

            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
            FrameworkElementFactory itemPres = new FrameworkElementFactory(typeof(ItemsPresenter));

            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(2));
            border.SetValue(Border.BorderThicknessProperty, new Thickness(2));
            border.SetValue(Border.BorderBrushProperty, AppDefinition.DarkTextColor);
            border.SetValue(Border.BackgroundProperty, AppDefinition.DefaultColor);

            itemPres.SetValue(ItemsPresenter.MarginProperty, new Thickness(2));

            border.AppendChild(itemPres);

            template.VisualTree = border;

            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            return style;
        }
        private ItemsPanelTemplate ContextItemMenuStyle()
        {
            FrameworkElementFactory panelFactory = new(typeof(StackPanel));
            panelFactory.SetValue(StackPanel.BackgroundProperty, AppDefinition.DefaultColor);

            ItemsPanelTemplate template = new();
            template.VisualTree = panelFactory;

            return template;
        }
    }
}
