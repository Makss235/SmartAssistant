using SmartAssistant.Data.ProgramsData;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab;
using SmartAssistant.UserControls.Widgets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SmartAssistant.Windows
{
    public class TestWindow : Window
    {
        Path a;
        Polygon myPolygon;
        public TestWindow()
        {
            SExpander sExpander = new SExpander();
            sExpander.HorizontalAlignment = HorizontalAlignment.Left;
            sExpander.VerticalAlignment = VerticalAlignment.Top;

            Line myLine = new Line
            {
                Stroke = Brushes.Green,
                X1 = 50, Y1 = 50,
                X2 = 100, Y2 = 100,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                StrokeThickness = 3,
            };

            myPolygon = new Polygon
            {
                Stroke = Brushes.Blue,
                Fill = Brushes.Pink,
                StrokeThickness = 3,
                Stretch = Stretch.Fill,
                Height = 50, Width = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Points = new PointCollection { new Point(0, 0), new Point(1, 0), new Point(1, 1) },
                Margin = new Thickness(50),
                RenderTransformOrigin = new Point(100, 100),
                LayoutTransform = new RotateTransform { Angle = 45 }
            };
            myPolygon.PreviewMouseLeftButtonDown += A_P;

            Grid grid = new Grid
            {
                Children = {  new TextBox() { Margin = new Thickness(200)}, myPolygon }
            };

            PE pE = new PE(Programs.JsonObject[2]);
            //Content = pE;

            Content = grid;
        }

        private void A_P(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            a.Fill = Brushes.Green;
            if (myPolygon.Fill == Brushes.Pink)
                myPolygon.Fill = Brushes.Green;
            else if (myPolygon.Fill == Brushes.Green)
                myPolygon.Fill = Brushes.Pink;
            
        }
    }
}
