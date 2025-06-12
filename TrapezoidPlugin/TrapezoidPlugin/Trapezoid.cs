using Newtonsoft.Json;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using MyPaint;


public class Trapezoid : ShapeAllKinds
{
    private Point[] points;

    private int strokeThickness;

    [JsonIgnore]
    private int StrokeThickness
    {
        get { return strokeThickness; }
        set
        {
            strokeThickness = value;
            FigurePtr.StrokeThickness = value;
        }
    }

    private Color fillColor, strokeColor;

    [JsonIgnore]
    private Color FillColor
    {
        get { return fillColor; }
        set
        {
            fillColor = value;
            FigurePtr.Fill = new SolidColorBrush(value);
        }
    }

    [JsonIgnore]
    private Color StrokeColor
    {
        get { return strokeColor; }
        set
        {
            strokeColor = value;
            FigurePtr.Stroke = new SolidColorBrush(value);
        }
    }

    [JsonIgnore] public override Shape FigurePtr { get; set; }

    public override void UpdateData(InformationForDraw informationForDraw)
    {
        (FigurePtr as Polygon).Points[0] = new Point(informationForDraw.xEnter, informationForDraw.yEnter);
        (FigurePtr as Polygon).Points[1] = new Point(informationForDraw.xEnter + 0.25 * (informationForDraw.xExit - informationForDraw.xEnter), informationForDraw.yExit);
        (FigurePtr as Polygon).Points[2] = new Point(informationForDraw.xEnter + 0.75 * (informationForDraw.xExit - informationForDraw.xEnter), informationForDraw.yExit);
        (FigurePtr as Polygon).Points[3] = new Point(informationForDraw.xExit  , informationForDraw.yEnter);

        points = (FigurePtr as Polygon).Points.ToArray();
        
        StrokeColor = informationForDraw.StrokeColor;
        StrokeThickness = informationForDraw.Thickness;
        FillColor  = informationForDraw.FillColor;
    }

    public override void Draw(InformationForDraw informationForDraw)
    {
        FigurePtr = new Polygon()
        {
            IsHitTestVisible = false,
            Points = new PointCollection
            {
                new Point(informationForDraw.xEnter, informationForDraw.yEnter),
                new Point(informationForDraw.xEnter + 0.25 * (informationForDraw.xEnter - informationForDraw.xExit), informationForDraw.yExit),
                new Point(informationForDraw.xEnter + 0.75 * (informationForDraw.xEnter - informationForDraw.xExit), informationForDraw.yExit),
                new Point(informationForDraw.xExit, informationForDraw.yEnter)
            },
        };
    }

    public override void Draw(Canvas canvas)
    {
        FigurePtr = new Polygon()
        {
            IsHitTestVisible = false,
        };
        
        {
            (FigurePtr as Polygon).Points = new PointCollection(points);
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeThickness = strokeThickness;
        }

        canvas.Children.Add(FigurePtr);
    }
}