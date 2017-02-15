using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using ThirtyRails.Utils;

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

        public static readonly DependencyProperty PipColorProperty = DependencyProperty.Register(
            "PipColor", typeof(Brush), typeof(Die), new PropertyMetadata(Brushes.Black, PropertyChangedCallback));

        public Brush PipColor
        {
            get { return (Brush)GetValue(PipColorProperty); }
            set { SetValue(PipColorProperty, value); }
        }

        public static readonly DependencyProperty DieColorProperty = DependencyProperty.Register(
            "DieColor", typeof(Brush), typeof(Die), new PropertyMetadata(Brushes.WhiteSmoke, PropertyChangedCallback));

        public Brush DieColor
        {
            get { return (Brush)GetValue(DieColorProperty); }
            set { SetValue(DieColorProperty, value); }
        }

        public static readonly DependencyProperty PipsProperty = DependencyProperty.Register(
            "Pips", typeof(int), typeof(Die), new PropertyMetadata(1, PropertyChangedCallback));

        public int Pips
        {
            get { return (int)GetValue(PipsProperty); }
            set { SetValue(PipsProperty, value); }
        }

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
            if (Pips.In(1, 3, 5))
            {
                _canvas.Children.Add(CreatePip(diameter, totalWidth / 2, totalHeight / 2));
            }

            if (Pips != 1)
            {
                _canvas.Children.Add(CreatePip(diameter, totalWidth / 4 * 3, totalHeight / 4));
                _canvas.Children.Add(CreatePip(diameter, totalWidth / 4, totalHeight / 4 * 3));
            }

            if (Pips.In(4, 5, 6))
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

        private UIElement CreatePip(double diameter, double x, double y)
        {
            var pip = new Ellipse();
            pip.Fill = PipColor;
            pip.Width = diameter;
            pip.Height = diameter;
            Canvas.SetLeft(pip, x - diameter / 2);
            Canvas.SetTop(pip, y - diameter / 2);
            return pip;
        }
    }
}
