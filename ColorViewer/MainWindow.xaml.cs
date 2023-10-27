using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorViewer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void trackBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.colorRectangle.Fill = new SolidColorBrush(Color.FromArgb((byte) this.aTrackBar.Value, (byte)this.rTrackBar.Value, (byte)this.gTrackBar.Value, (byte)this.bTrackBar.Value));
        }
    }
}
