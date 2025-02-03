using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Skip not arrow keys
            if (!(e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down))
                e.Handled = true;  
        }
    }
}
