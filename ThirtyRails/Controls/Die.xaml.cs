using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ThirtyRails.Controls
{
    /// <summary>
    /// Interaction logic for Die.xaml
    /// </summary>
    public partial class Die
    {
        public Die()
        {
            InitializeComponent();

            SizeChanged += Die_SizeChanged;
        }

        private void Die_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawPips();
        }

        public static readonly DependencyProperty PipsProperty = DependencyProperty.Register(
            "Pips", typeof(int), typeof(Die), new PropertyMetadata(1, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var die = dependencyObject as Die;
            die?.DrawPips();
        }

        private void DrawPips()
        {
            var totalWidth = Width;
            var totalHeight = Height;

            var diameter = Width * 0.2;

            _canvas.Children.Clear();
            if (Pips == 1 || Pips == 3 || Pips == 5)
            {
                _canvas.Children.Add(CreatePip(diameter, totalWidth / 2, totalHeight / 2));
            }

            if (Pips != 1)
            {
                _canvas.Children.Add(CreatePip(diameter, totalWidth / 4 * 3, totalHeight / 4));
                _canvas.Children.Add(CreatePip(diameter, totalWidth / 4, totalHeight / 4 * 3));
            }

            if (Pips == 4 || Pips == 5 || Pips == 6)
            {
                _canvas.Children.Add(CreatePip(diameter, totalWidth / 4, totalHeight / 4));
                _canvas.Children.Add(CreatePip(diameter, totalWidth / 4 * 3, totalHeight / 4 * 3));
            }

            if (Pips == 6)
            {
                _canvas.Children.Add(CreatePip(diameter, totalWidth / 4, totalHeight / 2));
                _canvas.Children.Add(CreatePip(diameter, totalWidth / 4 * 3, totalHeight / 2));
            }
        }

        private static UIElement CreatePip(double diameter, double x, double y)
        {
            var pip = new Ellipse();
            pip.Fill = Brushes.Black;
            pip.Width = diameter;
            pip.Height = diameter;
            Canvas.SetLeft(pip, x - diameter / 2);
            Canvas.SetTop(pip, y - diameter / 2);
            return pip;
        }

        public int Pips
        {
            get { return (int) GetValue(PipsProperty); }
            set { SetValue(PipsProperty, value); }
        }
    }
}
