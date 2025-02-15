using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;

namespace ProcessManager.Profiling.GraphFramework
{
    /// <summary>
    /// Class responsible for rendering graph.
    /// </summary>
    public class GraphRenderer
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        /// <summary>
        /// Current grid bitmap.
        /// </summary>
        public Bitmap? GridMap { get; private set; }

        /// <summary>
        /// Current data bitmap.
        /// </summary>
        public Bitmap? DataMap { get; private set; }

        /// <summary>
        /// Grid background color.
        /// </summary>
        public Color GridBackground { get; set; }

        /// <summary>
        /// Grid foreground color.
        /// </summary>
        public Color GridForeground { get; set; }

        /// <summary>
        /// Data foreground color.
        /// </summary>
        public Color DataForeground { get; set; }

        /// <summary>
        /// Previous graph width.
        /// </summary>
        public int PreviousWidth { get; set; }

        /// <summary>
        /// Previous graph height.
        /// </summary>
        public int PreviousHeight { get; set; }

        /// <summary>
        /// Current graph width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Current graph height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Size X of grid cell.
        /// </summary>
        public int CellSizeX { get; set; }

        /// <summary>
        /// Size Y of grid cell.
        /// </summary>
        public int CellSizeY { get; set; }

        /// <summary>
        /// Grid X cell count.
        /// </summary>
        public int CellCountX { get; set; }

        /// <summary>
        /// Grid Y cell count.
        /// </summary>
        public int CellCountY { get; set; }

        /// <summary>
        /// Current Grid X cycle shift.
        /// </summary>
        public int CycleOffsetX { get; set; }

        /// <summary>
        /// Current Grid Y cycle shift.
        /// </summary>
        public int CycleOffsetY { get; set; }

        /// <summary>
        /// Constant Grid X cycle shift.
        /// </summary>
        public int CycleOffsetConstantX => CellSizeX / GridCycleLengthX;

        /// <summary>
        /// Constant Grid Y cycle shift.
        /// </summary>
        public int CycleOffsetConstantY => CellSizeY / GridCycleLengthY;

        /// <summary>
        /// Current Data X shift value.
        /// </summary>
        public int DataOffsetX { get; set; }

        /// <summary>
        /// Current Data Y shift value.
        /// </summary>
        public int DataOffsetY { get; set; }

        /// <summary>
        /// Count of X cycles before completion.
        /// </summary>
        public int GridCycleLengthX { get; set; }

        /// <summary>
        /// Count of Y cycles before completion.
        /// </summary>
        public int GridCycleLengthY { get; set; }

        /// <summary>
        /// Maximum value data (100%).
        /// </summary>
        public double MaxDataValue { get; set; }

        /// <summary>
        /// Minimum value data (0%).
        /// </summary>
        public double MinDataValue { get; set; }
        
        /// <summary>
        /// Current Grid X cycle.
        /// </summary>
        private int currentCycleX = 1;

        /// <summary>
        /// Current Grid Y cycle.
        /// </summary>
        private int currentCycleY = 1;

        /// <summary>
        /// List of points.
        /// </summary>
        private List<PointF> dataPoints = new List<PointF>();

        //
        // ---------------------------------- CONSTRUCTORS ----------------------------------
        //

        public GraphRenderer(int width, int height)
        {
            PreviousWidth = width;
            PreviousHeight = height;
        }

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        /// <summary>
        /// Render grid given current parameters.
        /// </summary>
        /// <param name="width">Grid render width.</param>
        /// <param name="height">Grid render height.</param>
        /// <param name="cellCountX">Grid X cell count.</param>
        /// <param name="cellCountY">Grid Y cell count.</param>
        /// <param name="invertedCycle">Is cycle inverted</param>
        public void RenderGrid(int width, int height, int cellCountX = 20, int cellCountY = 10, bool invertedCycle = true)
        {
            if (height == 0 || width == 0)
                return;

            Width = width;
            Height = height;

            GridMap = new Bitmap(Width, Height);

            using (Graphics graphics = Graphics.FromImage(GridMap))
            {
                graphics.Clear(GridBackground);

                using (Pen pen = new Pen(GridForeground, 1))
                {
                    CellCountX = cellCountX;
                    CellCountY = cellCountY;

                    SetCellSize();
                    SetCycleOffset();

                    for (int x = 0; x < cellCountX + 1; x++)
                    {
                        for (int y = 0; y < cellCountY + 1; y++)
                        {
                            int offsetX = x * CellSizeX;
                            int offsetY = y * CellSizeY;

                            if (invertedCycle)
                                graphics.DrawRectangle(pen, offsetX - CycleOffsetX, offsetY - CycleOffsetY, CellSizeX, CellSizeY);
                            else
                                graphics.DrawRectangle(pen, offsetX + CycleOffsetX, offsetY + CycleOffsetY, CellSizeX, CellSizeY);
                        }
                    }
                 
                    currentCycleX++;
                    currentCycleY++;
                }
            }
        }
        /// <summary>
        /// Render data given current parameters.
        /// </summary>
        /// <param name="width">Data render width.</param>
        /// <param name="height">Data render height.</param>
        /// <param name="data">Data value to render.</param>
        public void RenderData(int width, int height, double data)
        {
            if (dataPoints.Count == 0)
                dataPoints.Add(new PointF(width, 0));
            
            if (DataMap == null || PreviousWidth != width || PreviousHeight != height)
                ResizeDataMap(width, height);

            using (Graphics graphics = Graphics.FromImage(DataMap!))
            {
                graphics.Clear(Color.Transparent);

                double normalized = Normalize((int)MinDataValue, (int)MaxDataValue, data);

                int yPosition = (int)(normalized * Height);
                int actualPositionY = yPosition + DataOffsetY;

                for (int i = 0; i < dataPoints.Count; i++)
                {
                    dataPoints[i] = new PointF(dataPoints[i].X - CycleOffsetConstantX, dataPoints[i].Y);

                    if (i > 0)
                        using (Pen pen = new Pen(DataForeground, 1))
                            graphics.DrawLine(pen, dataPoints[i - 1], dataPoints[i]);
                }

                if (data > MaxDataValue)
                    actualPositionY = (int)(.99 * Height) + DataOffsetY;
                else if (data < MinDataValue)
                    actualPositionY = (int)(0 * Height) + DataOffsetY;

                PointF newPoint = new PointF(width, actualPositionY);
                dataPoints.Add(newPoint);

                using (Pen pen = new Pen(DataForeground, 1))
                {
                    if (dataPoints.Count > 1)
                        graphics.DrawLine(pen, dataPoints[dataPoints.Count - 2], newPoint);
                }
            }
        }
        
        /// <summary>
        /// Combines <see cref="GridMap"/> and <see cref="DataMap"/>.
        /// </summary>
        /// <param name="inverted">Is inverted.</param>
        /// <returns>Image source of complete graph.</returns>
        public System.Windows.Media.ImageSource GetGraph(bool inverted = true)
        {
            Bitmap merged = new Bitmap(Width, Height);

            using (Graphics graphics = Graphics.FromImage(merged))
            {
                if (GridMap != null)
                    graphics.DrawImage(GridMap, 0, 0);

                if (DataMap != null)
                    graphics.DrawImage(DataMap, 0, 0);
            }

            if (inverted)
                merged.RotateFlip(RotateFlipType.RotateNoneFlipY);

            using (MemoryStream memory = new MemoryStream())
            {
                merged.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = memory;
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();
                return img;
            }
        }

        private void SetCellSize()
        {
            CellSizeX = (int)Math.Ceiling((double)Width / CellCountX);
            CellSizeY = (int)Math.Ceiling((double)Height / CellCountY);
        }
        private void SetCycleOffset()
        {
            if (currentCycleX == GridCycleLengthX)
                currentCycleX = 0;
            if (currentCycleY == GridCycleLengthY)
                currentCycleY = 0;

            int cycleOffsetX = 0;
            int cycleOffsetY = 0;

            if (GridCycleLengthX > 0)
            {
                int offsetX = (CellSizeX / GridCycleLengthX);

                cycleOffsetX = offsetX * currentCycleX;
                DataOffsetX += offsetX;
            }

            if (GridCycleLengthY > 0)
            {
                int offsetY = (CellSizeY / GridCycleLengthY);

                cycleOffsetY = offsetY * currentCycleY;
                DataOffsetY += offsetY;
            }

            CycleOffsetX = cycleOffsetX; 
            CycleOffsetY = cycleOffsetY;    
        }
        private void ResizeDataMap(int newWidth, int newHeight)
        {
            if (newWidth == 0 || newHeight == 0)
                return;

            if (DataMap != null)
                DataMap.Dispose();

            DataMap = new Bitmap(newWidth, newHeight);

            List<PointF> newPoints = new List<PointF>();

            using (Graphics g = Graphics.FromImage(DataMap))
            {
                g.Clear(Color.Transparent);

                using (Pen pen = new Pen(DataForeground, 1))
                {
                    for (int i = 0; i < dataPoints.Count; i++)
                    {
                        PointF newPoint = new PointF(
                            (dataPoints[i].X / PreviousWidth) * newWidth,
                            (dataPoints[i].Y / PreviousHeight) * newHeight
                        );

                        newPoints.Add(newPoint);

                        if (i > 0)
                            g.DrawLine(pen, newPoints[i - 1], newPoint);
                    }
                }
            }
            DataOffsetX = (int)Math.Round((DataOffsetX / (double)PreviousWidth) * newWidth);


            Width = newWidth;
            Height = newHeight;

            PreviousWidth = newWidth;
            PreviousHeight = newHeight;

            dataPoints = newPoints;
        }

        private double Normalize(int min, int max, double data)
        {
            double normalized = (double)(data - min) / (max - min);
            normalized = Math.Min(Math.Max(normalized, min), 1);

            return normalized;
        }
    }
}
