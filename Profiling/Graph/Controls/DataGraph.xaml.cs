using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows;

namespace ProcessManager.Profiling.GraphFramework.Controls
{
    /// <summary>
    /// Interaction logic for DataGraph.xaml
    /// </summary>
    public partial class DataGraph : UserControl
    {
        //
        //---------------------------------- PROPERTIES ----------------------------------
        //

        public GraphRenderer? Renderer { get; set; }

        public int GraphDelay { get; set; } = 1000;

        public SolidColorBrush GridBackground { get; set; } = new SolidColorBrush(Colors.Gray);
        public SolidColorBrush GridForeground { get; set; } = new SolidColorBrush(Colors.Black);
        public SolidColorBrush DataForeground { get; set; } = new SolidColorBrush(Colors.Yellow);

        public int CellCountX { get; set; } = 20;
        public int CellCountY { get; set; } = 10;

        public double GridCycleLengthX { get; set; } = 2;
        public double GridCycleLengthY { get; set; } = 0;

        public double MaxDataValue { get; set; } = 100;
        public double MinDataValue { get; set; } = 0.0;

        private CancellationTokenSource? _cancellationTokenSource;


        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register(
                "Data", typeof(double), typeof(DataGraph), new PropertyMetadata(0.0));
        public double Data
        {
            get { return (double)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        //
        // ---------------------------------- CONSTRUCTORS ----------------------------------
        //

        public DataGraph()
        {
            InitializeComponent();
        }

        //
        // ---------------------------------- EVENTS ----------------------------------
        //

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            _cancellationTokenSource = new CancellationTokenSource();

            RendererThread().Start();
        }
        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _cancellationTokenSource!.Cancel();
        }

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        private Thread RendererThread()
        {
            return new Thread(async () =>
            {
                Renderer = new GraphRenderer((int)ActualWidth, (int)ActualHeight);

                Renderer.GridCycleLengthX = (int)GridCycleLengthX;
                Renderer.GridCycleLengthY = (int)GridCycleLengthY;
                
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Renderer.GridBackground = SWMToSD(GridBackground.Color);
                    Renderer.GridForeground = SWMToSD(GridForeground.Color);
                    Renderer.DataForeground = SWMToSD(DataForeground.Color);
                });

                Renderer.CellCountX = CellCountX;
                Renderer.CellCountY = CellCountY;

                Renderer.MaxDataValue = MaxDataValue;
                Renderer.MinDataValue = MinDataValue;

                if (_cancellationTokenSource == null)
                    return;

                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    if (_cancellationTokenSource.IsCancellationRequested)
                        return;

                    Dispatcher.Invoke(() =>
                    {
                        Renderer.RenderGrid((int)ActualWidth, (int)ActualHeight);

                        Renderer.RenderData((int)ActualWidth, (int)ActualHeight, Data);

                        GraphDisplayer.Source = Renderer.GetGraph();
                    });

                    await Task.Delay(GraphDelay);
                }
            });
        }
        private System.Drawing.Color SWMToSD(System.Windows.Media.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}
