using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace MyPaint;

internal class RectangleDefault : ShapeAllKinds
{
    private double x1, y1, x2, y2;
    
    [JsonIgnore]
    private double X1
    {
        get { return x1; }
        set { x1 = value; }
    }

    [JsonIgnore]
    private double X2
    {
        get { return x2; }
        set
        {
            x2 = value;
            Canvas.SetLeft(FigurePtr, x2 > x1 ? x1 : x2);
            FigurePtr.Width = Math.Abs(x2 - x1);
        }
    }

    [JsonIgnore]
    private double Y1
    {
        get { return y1; }
        set { y1 = value; }
    }

    [JsonIgnore]
    private double Y2
    {
        get { return y2; }
        set
        {
            y2 = value;
            Canvas.SetTop(FigurePtr, y2 > y1 ? y1 : y2);
            FigurePtr.Height = Math.Abs(y2 - y1);
        }
    }

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
        X1 = informationForDraw.xEnter;
        Y1 = informationForDraw.yEnter;
        X2 = informationForDraw.xExit;
        Y2 = informationForDraw.yExit;

        StrokeColor = informationForDraw.StrokeColor;
        FillColor = informationForDraw.FillColor;
        StrokeThickness = informationForDraw.Thickness;
    }

    public override void Draw(InformationForDraw informationForDraw)
    {
        FigurePtr = new Rectangle()
        {
            IsHitTestVisible = false,
        };
    }

    public override void Draw(Canvas canvas)
    {
        FigurePtr = new Rectangle()
        {
            IsHitTestVisible = false,
        };

        // рисовка фигуры
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            StrokeColor = strokeColor;
            FillColor = fillColor;
            StrokeThickness = strokeThickness;
        }

        canvas.Children.Add(FigurePtr);
    }
}