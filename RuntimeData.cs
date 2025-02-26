using ProcessManager.Profiling.Models.Process;
using ProcessManager.Windows.ProcessContext;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using ProcessManager.Actions;
using System.Windows;

namespace ProcessManager
{
    public static class RuntimeData
    {
        //
        // ---------------------------------- RUNTIME ----------------------------------
        //

        public static ObservableCollection<ProcessInfo> Processes = new ObservableCollection<ProcessInfo>();
        public static HashSet<uint> Running = new HashSet<uint>();

        public static ProcessInfo? SelectedProcess { get; set; }
        public static uint SelectedProcessPID => SelectedProcess == null ? uint.MaxValue : SelectedProcess.PID;
        
        //
        // ---------------------------------- UI ----------------------------------
        //

        public static ContextMenu? ProcessContextMenu { get; set; }
        public static ContextMenu? ProcessPriorityContextMenu { get; set; }

        // ---------------------------------- PROCESS CONTEXT MENU ----------------------------------
        public static void CreateProcessContextMenu()
        {
            if (ProcessContextMenu == null)
            {
                Separator separator = new Separator();

                MenuItem killProcessButton = new MenuItem() { Header = "Kill Process", Foreground = AppDefinition.LightTextColor };
                killProcessButton.Click += (s, a) => ProcessActions.KillProcess(SelectedProcessPID);    

                MenuItem suspendProcessButton = new MenuItem() { Header = "Suspend Process", Foreground = AppDefinition.LightTextColor };
                suspendProcessButton.Click += (s, a) => ProcessActions.SuspendProcess(SelectedProcessPID);

                MenuItem resumeProcessButton = new MenuItem() { Header = "Resume Process", Foreground = AppDefinition.LightTextColor };
                resumeProcessButton.Click += (s, a) => ProcessActions.ResumeProcess(SelectedProcessPID);

                MenuItem setAffinityButton = new MenuItem() { Header = "Set Affinity", Foreground = AppDefinition.LightTextColor };
                setAffinityButton.Click += (s, a) => AffinityButtonClick();

                MenuItem setPriorityButton = new MenuItem() { Header = "Set Priority", Foreground = AppDefinition.LightTextColor};
                setPriorityButton.Click += (s, a) => PriorityButtonClick();

                object[] buttons = [killProcessButton, suspendProcessButton, resumeProcessButton, setAffinityButton, setPriorityButton];

                ProcessContextMenu = new();

                ProcessContextMenu.Style = ContextMenuStyle();
                ProcessContextMenu.ItemsPanel = ContextItemMenuStyle();

                foreach (object b in buttons)
                    ProcessContextMenu.Items.Add(b);
            }
        }
        private static Style ContextMenuStyle()
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
        private static ItemsPanelTemplate ContextItemMenuStyle()
        {
            FrameworkElementFactory panelFactory = new(typeof(StackPanel));
            panelFactory.SetValue(StackPanel.BackgroundProperty, AppDefinition.DefaultColor);

            ItemsPanelTemplate template = new();
            template.VisualTree = panelFactory;

            return template;
        }
    
        private static void AffinityButtonClick()
        {
            ProcessAffinityWindow affinityWindow = new ProcessAffinityWindow(SelectedProcess ?? throw new Exception());
            affinityWindow.Show();
        }   
        
        private static void PriorityButtonClick()
        {
            ProcessPriorityWindow priorityWindow = new ProcessPriorityWindow(SelectedProcess ?? throw new Exception());
            priorityWindow.ShowDialog();
        }
    }
}
