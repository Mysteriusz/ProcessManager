using ProcessManager.Pages.ProcessProperties;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;

namespace ProcessManager.Windows
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesWindow.xaml
    /// </summary>
    public partial class ProcessPropertiesWindow : Window
    {
        public ProcessPropertiesWindow()
        {
            InitializeComponent();
        }

        private readonly ProcessPropertiesGeneralPage _generalPage = new();
        private readonly ProcessPropertiesStatisticsPage _statsPage = new();
        private readonly ProcessPropertiesModulesPage _modulesPage = new();
        private readonly ProcessPropertiesHandlesPage _handlesPage = new();
        private readonly ProcessPropertiesThreadsPage _threadsPage = new();
        private readonly ProcessPropertiesPerformancePage _performancePage = new();

        private void PropertiesButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {   
            if (sender is Border border && e.ChangedButton == MouseButton.Left)
            {
                switch (border.Tag)
                {
                    case "General":
                        _generalPage.DataContext = this.DataContext;
                        PropertiesPageFrame.Navigate(_generalPage);
                        break;
                    case "Statistics":
                        _statsPage.DataContext = this.DataContext;
                        PropertiesPageFrame.Navigate(_statsPage);
                        break;
                    case "Performance":
                        _performancePage.DataContext = this.DataContext;
                        PropertiesPageFrame.Navigate(_performancePage);
                        break;
                    case "Handles":
                        _handlesPage.DataContext = this.DataContext;
                        PropertiesPageFrame.Navigate(_handlesPage);
                        break;
                    case "Modules":
                        _modulesPage.DataContext = this.DataContext;
                        PropertiesPageFrame.Navigate(_modulesPage);
                        break;
                    case "Threads":
                        _threadsPage.DataContext = this.DataContext;
                        PropertiesPageFrame.Navigate(_threadsPage);
                        break;
                }
            }
        }

        private void PropertiesPageFrame_Loaded(object sender, RoutedEventArgs e)
        {
            ProcessPropertiesGeneralPage generalPage = new ProcessPropertiesGeneralPage();
            generalPage.DataContext = this.DataContext;
            PropertiesPageFrame.Navigate(generalPage);
        }
    }
}