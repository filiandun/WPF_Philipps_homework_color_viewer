using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ColorViewer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NewColor newColor;

        public MainWindow()
        {
            InitializeComponent();

            this.newColor = new NewColor(255, 154, 185, 255);

            this.aTextBox.Text = this.newColor.A.ToString();
            this.rTextBox.Text = this.newColor.R.ToString();
            this.gTextBox.Text = this.newColor.G.ToString();
            this.bTextBox.Text = this.newColor.B.ToString();

            this.aTrackBar.Value = this.newColor.A;
            this.rTrackBar.Value = this.newColor.R;
            this.gTrackBar.Value = this.newColor.G;
            this.bTrackBar.Value = this.newColor.B;

            this.aCheckBox.IsChecked = true;
            this.rCheckBox.IsChecked = true;
            this.gCheckBox.IsChecked = true;
            this.bCheckBox.IsChecked = true;
        }


        private void aTrackBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.newColor.A = (byte)this.aTrackBar.Value;
            this.aTextBox.Text = $"{(byte) this.aTrackBar.Value}";
            
            this.UpdateColorRectangle();
        }

        private void rTrackBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.newColor.R = (byte) this.rTrackBar.Value;
            this.rTextBox.Text = $"{(byte)this.rTrackBar.Value}";

            this.UpdateColorRectangle();
        }

        private void gTrackBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.newColor.G = (byte) this.gTrackBar.Value;
            this.gTextBox.Text = $"{(byte)this.gTrackBar.Value}";

            this.UpdateColorRectangle();
        }

        private void bTrackBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.newColor.B = (byte) this.bTrackBar.Value;
            this.bTextBox.Text = $"{(byte)this.bTrackBar.Value}";

            this.UpdateColorRectangle();
        }

        private void UpdateColorRectangle()
        {
            this.colorRectangle.Fill = this.newColor.GetColor();
        }

        private void aTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (int.TryParse(this.aTextBox.Text, out int num))
            {
                if (num > 255)
                {
                    num = 255;
                    this.aTextBox.Text = num.ToString();
                }
                this.newColor.A = (byte) num;
                this.aTrackBar.Value = num;
            }
            else
            {
                this.newColor.A = 0;
                this.aTrackBar.Value = 0;
                this.aTextBox.Text = "0";
            }
        }

        private void rTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (int.TryParse(this.rTextBox.Text, out int num))
            {
                if (num > 255)
                {
                    num = 255;
                    this.rTextBox.Text = num.ToString();
                }
                this.newColor.R = (byte) num;
                this.rTrackBar.Value = num;
            }
            else
            {
                this.newColor.R = 0;
                this.rTrackBar.Value = 0;
                this.rTextBox.Text = "0";
            }
        }

        private void gTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (int.TryParse(this.gTextBox.Text, out int num))
            {
                if (num > 255)
                {
                    num = 255;
                    this.gTextBox.Text = num.ToString();
                }
                this.newColor.G = (byte) num;
                this.gTrackBar.Value = num;
            }
            else
            {
                this.newColor.G = 0;
                this.gTrackBar.Value = 0;
                this.gTextBox.Text = "0";
            }
        }

        private void bTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (int.TryParse(this.bTextBox.Text, out int num))
            {
                if (num > 255)
                {
                    num = 255;
                    this.bTextBox.Text = num.ToString();
                }
                this.newColor.B = (byte) num;
                this.bTrackBar.Value = num;
            }
            else
            {
                this.newColor.B = 0;
                this.bTrackBar.Value = 0;
                this.bTextBox.Text = "0";
            }
        }

        private void aCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.aCheckBox.IsChecked.Value)
            {
                this.aTextBox.IsEnabled = true;
                this.aTrackBar.IsEnabled = true;
            }
            else
            {
                this.aTextBox.IsEnabled = false;
                this.aTrackBar.IsEnabled = false;
            }
        }

        private void rCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.rCheckBox.IsChecked.Value)
            {
                this.rTextBox.IsEnabled = true;
                this.rTrackBar.IsEnabled = true;
            }
            else
            {
                this.rTextBox.IsEnabled = false;
                this.rTrackBar.IsEnabled = false;
            }
        }

        private void gCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.gCheckBox.IsChecked.Value)
            {
                this.gTextBox.IsEnabled = true;
                this.gTrackBar.IsEnabled = true;
            }
            else
            {
                this.gTextBox.IsEnabled = false;
                this.gTrackBar.IsEnabled = false;
            }
        }

        private void bCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.bCheckBox.IsChecked.Value)
            {
                this.bTextBox.IsEnabled = true;
                this.bTrackBar.IsEnabled = true;
            }
            else
            {
                this.bTextBox.IsEnabled = false;
                this.bTrackBar.IsEnabled = false;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = new Grid
            {
                Width = 220,
                Height = 26
            };

            ColumnDefinition columnDefinition1 = new ColumnDefinition();
            ColumnDefinition columnDefinition2 = new ColumnDefinition();
            ColumnDefinition columnDefinition3 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(columnDefinition1);
            grid.ColumnDefinitions.Add(columnDefinition2);
            grid.ColumnDefinitions.Add(columnDefinition3);

            Label label = new Label
            {
                Content = this.newColor.GetHexColor(),
                FontFamily = new FontFamily("Segoe UI Variable Display Semibold"),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 175, 206, 255)),
                FontSize = 12
            };

            System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle
            {
                Fill = this.newColor.GetColor(),
                Margin = new Thickness(5),
                Stroke = new SolidColorBrush(Color.FromArgb(255, 175, 206, 255)),
                RadiusX = 5, 
                RadiusY = 5, 
                StrokeThickness = 2,
            };

            Grid.SetColumn(label, 0);
            Grid.SetColumn(rectangle, 1);

            Grid.SetColumnSpan(rectangle, 2);

            grid.Children.Add(label);
            grid.Children.Add(rectangle);

            this.colorsListBox.Items.Add(grid);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.colorsListBox.SelectedIndex != -1)
            {
                this.colorsListBox.Items.RemoveAt(this.colorsListBox.SelectedIndex);
            }
        }
    }
}
