using System.Windows;
using System.Media;

namespace ProcessManager.Windows
{
    /// <summary>
    /// Interaction logic for ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        public ConfirmWindow()
        {
            InitializeComponent();
        }

        public void Yes_ButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        public void No_ButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SystemSounds.Exclamation.Play();
        }
    }
}
