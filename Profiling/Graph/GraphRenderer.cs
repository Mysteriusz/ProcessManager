using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Media3D;

namespace ProcessManager.Profiling.GraphFramework
{
    public class GraphRenderer
    {
        public Bitmap? GridMap { get; set; }
        public Bitmap? DataMap { get; set; }

        public int PreviousWidth { get; set; }
        public int PreviousHeight { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        
        public int CellSizeX { get; set; }
        public int CellSizeY { get; set; }

        public int CellCountX { get; set; }
        public int CellCountY { get; set; }

        public int CycleOffsetX { get; set; }
        public int CycleOffsetY { get; set; }

        public int DataOffsetX { get; set; }
        public int DataOffsetY { get; set; }

        public int GridCycleLengthX { get; set; } = 3;
        public int GridCycleLengthY { get; set; } = 0;
        
        public double MaxDataValue { get; set; } = 100.0;
        public double MinDataValue { get; set; } = 0.0;

        private int currentCycleX = 1;
        private int currentCycleY = 1;

        private List<PointF> dataPoints = new List<PointF>() { new PointF(0, 0) };

        public GraphRenderer(int width, int height)
        {
            PreviousWidth = width;
            PreviousHeight = height;
        }

        public System.Windows.Media.ImageSource RenderGrid(int width, int height, int cellCountX = 20, int cellCountY = 10, bool invertedCycle = true)
        {
            Width = width;
            Height = height;

            GridMap = new Bitmap(Width, Height);

            using (Graphics graphics = Graphics.FromImage(GridMap))
            {
                graphics.Clear(Color.DarkGray);

                using (Pen pen = new Pen(Color.Black, 1))
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

            using (MemoryStream memory = new MemoryStream())
            {
                GridMap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = memory;
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();
                return img;
            }
        }
        public System.Windows.Media.ImageSource RenderData(int width, int height, double data)
        {
            if (DataMap == null || PreviousWidth != width || PreviousHeight  != height)
                ResizeDataMap(width, height);

            using (Graphics graphics = Graphics.FromImage(DataMap!))
            {
                double normalized = Normalize((int)MinDataValue, (int)MaxDataValue, data);

                int yPosition = (int)(normalized * Height);
                int actualPositionY;

                if (data > MaxDataValue)
                    actualPositionY = (int)(.99 * Height) + DataOffsetY;
                else if (data < MinDataValue)
                    actualPositionY = (int)(0 * Height) + DataOffsetY;
                else
                    actualPositionY = yPosition + DataOffsetY;

                PointF newPoint = new PointF(DataOffsetX, actualPositionY);
                dataPoints.Add(newPoint);

                using (Pen pen = new Pen(Color.Yellow, 1))
                {
                    if (dataPoints.Count > 1)
                        graphics.DrawLine(pen, dataPoints[dataPoints.Count - 2], newPoint);
                }
            }

            using (MemoryStream memory = new MemoryStream())
            {
                DataMap!.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = memory;
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();
                return img;
            }
        }
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

        private double Normalize(int min, int max, double data)
        {
            double normalized = (double)(data - min) / (max - min);
            normalized = Math.Min(Math.Max(normalized, min), 1);

            return normalized;
        }
        private void ResizeDataMap(int newWidth, int newHeight)
        {
            if (DataMap != null)
                DataMap.Dispose();

            DataMap = new Bitmap(newWidth, newHeight);

            List<PointF> newPoints = new List<PointF>();

            using (Graphics g = Graphics.FromImage(DataMap))
            {
                g.Clear(Color.Transparent);

                using (Pen pen = new Pen(Color.Yellow, 1))
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
    }
}
