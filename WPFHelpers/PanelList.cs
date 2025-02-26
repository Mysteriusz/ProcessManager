using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ProcessManager.WPFHelpers
{
    public partial class PanelList : UserControl
    {
        public static DependencyProperty RowCountProperty = DependencyProperty.Register("RowCount", typeof(uint), typeof(PanelList));
        public static DependencyProperty ColumnCountProperty = DependencyProperty.Register("ColumnCount", typeof(uint), typeof(PanelList));
        public static DependencyProperty CellStyleProperty = DependencyProperty.Register("CelLStyle", typeof(Style), typeof(PanelList));
        public static DependencyProperty ItemSourceProperty = DependencyProperty.Register("ItemSource", typeof(IEnumerable<object>), typeof(PanelList));

        public uint RowCount
        {
            get { return (uint)GetValue(RowCountProperty); }
            set { SetValue(RowCountProperty, value); }
        }
        public uint ColumnCount
        {
            get { return (uint)GetValue(ColumnCountProperty); }
            set { SetValue(ColumnCountProperty, value); }
        }
        public Style CellStyle
        {
            get { return (Style)GetValue(CellStyleProperty); }
            set { SetValue(CellStyleProperty, value); }
        }
        public IEnumerable<object> ItemSource
        {
            get { return (IEnumerable<object>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        public Dictionary<int, KeyValuePair<DependencyProperty, object>> Constraints { get; set; } = new Dictionary<int, KeyValuePair<DependencyProperty, object>>();
        public List<UIElement> Elements = new List<UIElement>();

        public PanelList() { }

        public void GenerateOrder()
        {
            int cellIndex = 0;

            Grid grid = new Grid() { Margin = new Thickness(10) };

            for (int c = 0; c < ColumnCount; c++)
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int r = 0; r < RowCount; r++)
                grid.RowDefinitions.Add(new RowDefinition());

            for (int c = 0; c < ColumnCount; c++)
            {
                for (int r = 0; r < RowCount; r++)
                {
                    UIElement cell = Activator.CreateInstance(CellStyle.TargetType) as UIElement ?? throw new Exception();
                     
                    cell.SetValue(WidthProperty, grid.Width / ColumnCount);
                    cell.SetValue(HeightProperty, grid.Height / RowCount);
                    cell.SetValue(StyleProperty, CellStyle);
                    cell.SetValue(ContentProperty, ItemSource.ElementAt(cellIndex));

                    foreach (var constraint in Constraints.Where(c => c.Key == cellIndex))
                        cell.SetValue(constraint.Value.Key, constraint.Value.Value);

                    Grid.SetColumn(cell, c);
                    Grid.SetRow(cell, r);
                    grid.Children.Add(cell);
                    Elements.Add(cell);

                    cellIndex++;
                }
            }

            Content = grid;
        }
    }
}
