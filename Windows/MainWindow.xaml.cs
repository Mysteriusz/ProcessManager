using ProcessManager.Profiling.Models.Cpu;
using ProcessManager.Pages.SystemInfo;
using ProcessManager.Pages;
using System.Windows;
using System.Diagnostics;
using System.Windows.Input;
using ProcessManager.Profiling.Models.Gpu;

namespace ProcessManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Row 1
        private ApplicationPage? _applicationPage;

        // Row 2

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainPageFrame_Loaded(object sender, RoutedEventArgs e)
        {
            _applicationPage = new();
            MainPageFrame.Navigate(_applicationPage);
        }
        
        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var c1 = MainGrid.RowDefinitions[2];
            var c2 = MainGrid.RowDefinitions[4];

            var c1Height = c1.Height.Value;
            var c2Height = c2.Height.Value;

            double delta = e.VerticalChange;

            if (double.IsNegative(e.VerticalChange))
            {
                if (c1Height + delta <= c1.MinHeight)
                    return;

                c1.Height = new GridLength(c1Height + delta, GridUnitType.Star);
                c2.Height = new GridLength(c2Height - delta, GridUnitType.Star);
            }
            else
            {
                if (c2Height - delta <= c2.MinHeight)
                    return;

                c1.Height = new GridLength(c1Height + delta, GridUnitType.Star);
                c2.Height = new GridLength(c2Height - delta, GridUnitType.Star);
            }
        }
    }
}