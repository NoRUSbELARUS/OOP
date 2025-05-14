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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Line line = new Line
            {
                X1 = 50,
                Y1 = 50,
                X2 = 200,
                Y2 = 50,
                Stroke = Brushes.Black
            };
            GraphicsCanvas.Children.Add(line);

            Rectangle rect = new Rectangle
            {
                Width = 150,
                Height = 100,
                Stroke = Brushes.Blue
            };
            Canvas.SetLeft(rect, 50);
            Canvas.SetTop(rect, 100);
            GraphicsCanvas.Children.Add(rect);

            Ellipse ellipse = new Ellipse
            {
                Width = 120,
                Height = 80,
                Stroke = Brushes.Red
            };
            Canvas.SetLeft(ellipse, 250);
            Canvas.SetTop(ellipse, 100);
            GraphicsCanvas.Children.Add(ellipse);

            Polygon polygon = new Polygon
            {
                Points = new PointCollection(new Point[]
                {
                    new Point(400, 150),
                    new Point(450, 250),
                    new Point(350, 250)
                }),
                Stroke = Brushes.Green
            };
            GraphicsCanvas.Children.Add(polygon);

            Polyline polyline = new Polyline
            {
                Points = new PointCollection(new Point[]
                {
                    new Point(550, 50),
                    new Point(600, 100),
                    new Point(650, 50),
                    new Point(700, 100)
                }),
                Stroke = Brushes.Purple
            };
            GraphicsCanvas.Children.Add(polyline);
        }
    }
}