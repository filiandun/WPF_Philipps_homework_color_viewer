using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ColorViewer
{
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

            this.aSlider.Value = this.newColor.A;
            this.rSlider.Value = this.newColor.R;
            this.gSlider.Value = this.newColor.G;
            this.bSlider.Value = this.newColor.B;
        }



        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {  
                switch (slider.Name)
                {
                    case "aSlider": 
                        this.newColor.A = (byte) this.aSlider.Value;
                        this.aTextBox.Text = $"{(byte) this.aSlider.Value}";
                        break;

                    case "rSlider":
                        this.newColor.R = (byte) this.rSlider.Value;
                        this.rTextBox.Text = $"{(byte) this.rSlider.Value}";
                        break;

                    case "gSlider":
                        this.newColor.G = (byte) this.gSlider.Value;
                        this.gTextBox.Text = $"{(byte) this.gSlider.Value}";
                        break;

                    case "bSlider":
                        this.newColor.B = (byte) this.bSlider.Value;
                        this.bTextBox.Text = $"{(byte) this.bSlider.Value}";
                        break;
                }

                this.UpdateColorRectangle();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                switch (textBox.Name)
                {
                    case "aTextBox":
                        this.UpdateForTextBox(ref this.aTextBox, 0, ref this.aSlider);
                        break;

                    case "rTextBox":
                        this.UpdateForTextBox(ref this.rTextBox, 1, ref this.rSlider);
                        break;

                    case "gTextBox":
                        this.UpdateForTextBox(ref this.gTextBox, 2, ref this.gSlider);
                        break;

                    case "bTextBox":
                        this.UpdateForTextBox(ref this.bTextBox, 3, ref this.bSlider);
                        break;
                }
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                switch (checkBox.Name)
                {
                    case "aCheckBox":
                        this.UpdateForCheckBox(ref this.aCheckBox, ref this.aTextBox, ref this.aSlider);
                        break;

                    case "rCheckBox":
                        this.UpdateForCheckBox(ref this.rCheckBox, ref this.rTextBox, ref this.rSlider);
                        break;

                    case "gCheckBox":
                        this.UpdateForCheckBox(ref this.gCheckBox, ref this.gTextBox, ref this.gSlider);
                        break;

                    case "bCheckBox":
                        this.UpdateForCheckBox(ref this.bCheckBox, ref this.bTextBox, ref this.bSlider);
                        break;
                }
            }
        }

        

        private void UpdateColorRectangle()
        {
            this.colorRectangle.Fill = this.newColor.GetColor();
        }

        private void UpdateForTextBox(ref TextBox textBox, byte index, ref Slider slider)
        {
            if (int.TryParse(textBox.Text, out int num))
            {
                if (num > 255)
                {
                    num = 255;
                    textBox.Text = num.ToString();
                }
                textBox.SelectionStart = textBox.Text.Length;
                this.newColor[index] = (byte) num;
                slider.Value = num;
            }
            else
            {
                textBox.Text = "0";
                textBox.SelectionStart = textBox.Text.Length;
                this.newColor[index] = 0;
                slider.Value = 0;
            }
        }

        private void UpdateForCheckBox(ref CheckBox checkBox, ref TextBox textBox, ref Slider slider)
        {
            if (checkBox.IsChecked.Value)
            {
                textBox.IsEnabled = true;
                slider.IsEnabled = true;
            }
            else
            {
                textBox.IsEnabled = false;
                slider.IsEnabled = false;
            }
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = new Grid
            {
                Width = 220,
                Height = 26
            };

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

            ColumnDefinition columnDefinition1 = new ColumnDefinition();
            ColumnDefinition columnDefinition2 = new ColumnDefinition();
            ColumnDefinition columnDefinition3 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(columnDefinition1);
            grid.ColumnDefinitions.Add(columnDefinition2);
            grid.ColumnDefinitions.Add(columnDefinition3);

            Grid.SetColumn(label, 0);
            Grid.SetColumn(rectangle, 1);

            Grid.SetColumnSpan(rectangle, 2);

            grid.Children.Add(label);
            grid.Children.Add(rectangle);

            this.colorsListBox.Items.Add(grid);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.colorsListBox.SelectedIndex != -1)
            {
                this.colorsListBox.Items.RemoveAt(this.colorsListBox.SelectedIndex);
            }
        }
    }
}
