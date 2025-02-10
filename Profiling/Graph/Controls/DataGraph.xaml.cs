using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace ProcessManager.Profiling.GraphFramework.Controls
{
    /// <summary>
    /// Interaction logic for DataGraph.xaml
    /// </summary>
    public partial class DataGraph : UserControl
    {
        public GraphRenderer? Renderer { get; set; }
        
        public int GraphDelay { get; set; }
        public int RenderWidth { get; set; }
        public int RenderHeight { get; set; }

        public int GridCycleLengthX { get; set; } = -1;
        public int GridCycleLengthY { get; set; } = -1;


        private CancellationTokenSource? _cancellationTokenSource;

        public DataGraph()
        {
            InitializeComponent();
        }

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

        private Thread RendererThread()
        {
            return new Thread(async () =>
            {
                Renderer = new GraphRenderer((int)ActualWidth, (int)ActualHeight);

                if (GridCycleLengthX >= 0)
                    Renderer.GridCycleLengthX = GridCycleLengthX;
                
                if (GridCycleLengthY >= 0)
                    Renderer.GridCycleLengthY = GridCycleLengthY;

                if (_cancellationTokenSource == null)
                    return;

                double data = 0;
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    if (_cancellationTokenSource.IsCancellationRequested)
                        return;

                    Dispatcher.Invoke(() =>
                    {
                        Renderer.RenderGrid((int)ActualWidth, (int)ActualHeight);
                        Renderer.RenderData((int)ActualWidth, (int)ActualHeight, data);

                        GraphDisplayer.Source = Renderer.GetGraph();
                    });

                    await Task.Delay(GraphDelay);
                }
            });
        }
    }
}
