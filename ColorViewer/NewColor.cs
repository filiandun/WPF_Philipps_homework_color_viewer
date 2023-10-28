using System.Drawing;
using System.Windows.Media;

namespace ColorViewer
{
    internal class NewColor
    {
        private byte a;
        private byte r;
        private byte g;
        private byte b;

        public byte A { get => a; set => a = value; }
        public byte R { get => r; set => r = value; }
        public byte G { get => g; set => g = value; }
        public byte B { get => b; set => b = value; }

        public NewColor(byte a, byte r, byte g, byte b) 
        { 
            this.a = a;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public SolidColorBrush GetColor()
        {
            return new SolidColorBrush(System.Windows.Media.Color.FromArgb(this.a, this.r, this.g, this.b));
        }

        public string GetHexColor()
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                     this.a,
                     this.r,
                     this.g,
                     this.b);
        }

    }
}
