using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace ProcessManager.Pages.ProcessProperties
{
    /// <summary>
    /// Interaction logic for ProcessPropertiesGeneralPage.xaml
    /// </summary>
    public partial class ProcessPropertiesGeneralPage : Page
    {
        public ProcessPropertiesGeneralPage()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Skip not arrow keys
            if (!(e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down))
                e.Handled = true;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Border? button = sender as Border;
                Grid? grid = button!.Parent as Grid;
                Border? textBorder = grid!.FindName("TextBorder") as Border;
                TextBox? textBox = textBorder!.FindName("TextBlock") as TextBox;

                Clipboard.SetText(textBox!.Text);
            }
        }
    }
}
