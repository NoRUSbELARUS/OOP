using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Newtonsoft.Json;


namespace MyPaint;

public class LineDefault : ShapeAllKinds
{
    public double x1, y1, x2, y2;

    [JsonIgnore]
    public double X1
    {
        get { return x1; }
        set
        {
            x1 = value;
            (FigurePtr as Line).X1 = value;
        }
    }

    [JsonIgnore]
    public double X2
    {
        get { return x2; }
        set
        {
            x2 = value;

            // Canvas.SetLeft(FigurePtr, x2 > x1 ? x1 : x2);
            (FigurePtr as Line).X2 = value;
        }
    }

    [JsonIgnore]
    public double Y1
    {
        get { return y1; }
        set
        {
            y1 = value;
            (FigurePtr as Line).Y1 = value;
        }
    }

    [JsonIgnore]
    public double Y2
    {
        get { return y2; }
        set
        {
            y2 = value;

            (FigurePtr as Line).Y2 = value;
            // Canvas.SetTop(FigurePtr, y2 > y1 ? y1 : y2);
            // FigurePtr.Height = Math.Abs(y2 - y1);
        }
    }

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

    public Color strokeColor;

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
        X1 = informationForDraw.xEnter;
        Y1 = informationForDraw.yEnter;
        X2 = informationForDraw.xExit;
        Y2 = informationForDraw.yExit;

        StrokeThickness = informationForDraw.Thickness;
        StrokeColor = informationForDraw.StrokeColor;
    }

    public override void Draw(InformationForDraw informationForDraw)
    {
        FigurePtr = new Line()
        {
            IsHitTestVisible = false,
        };
    }

    public override void Draw(Canvas canvas)
    {
        FigurePtr = new Line()
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
            StrokeThickness = strokeThickness;
        }

        canvas.Children.Add(FigurePtr);
    }
}