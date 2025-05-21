using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using Newtonsoft.Json;

namespace MyPaint;

public class PolygonDefault : ShapeAllKinds
{
    public Point[] points;

    public int strokeThickness;

    [JsonIgnore]
    public int StrokeThickness
    {
        get { return strokeThickness; }
        set
        {
            strokeThickness = value;
            FigurePtr.StrokeThickness = value;
        }
    }

    public Color fillColor, strokeColor;

    [JsonIgnore]
    public Color FillColor
    {
        get { return fillColor; }
        set
        {
            fillColor = value;
            FigurePtr.Fill = new SolidColorBrush(value);
        }
    }

    [JsonIgnore]
    public Color StrokeColor
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
        (FigurePtr as Polygon).Points[^1] = new Point(informationForDraw.xExit, informationForDraw.yExit);
        points = (FigurePtr as Polygon).Points.ToArray();

        if (InformationForDraw.ShiftWasPressed)
        {
            (FigurePtr as Polygon).Points.Add(new Point(informationForDraw.xExit, informationForDraw.yExit));
            InformationForDraw.ShiftWasPressed = false;
        }

        FillColor = informationForDraw.FillColor;
        StrokeColor = informationForDraw.StrokeColor;
        StrokeThickness = informationForDraw.Thickness;
    }

    public override void Draw(InformationForDraw informationForDraw)
    {
        FigurePtr = new Polygon()
        {
            IsHitTestVisible = false,
            Points = new PointCollection
            {
                new Point(informationForDraw.xEnter, informationForDraw.yEnter),
                new Point(informationForDraw.xExit, informationForDraw.yExit)
            },
        };
        
    }

    public override void Draw(Canvas canvas)
    {
        FigurePtr = new Polygon()
        {
            IsHitTestVisible = false,
        };

        // отрисовОчка
        {
            (FigurePtr as Polygon).Points = new PointCollection(points);
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeThickness = strokeThickness;
        }

        canvas.Children.Add(FigurePtr);
    }
}