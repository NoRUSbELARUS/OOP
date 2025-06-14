﻿using Newtonsoft.Json;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace MyPaint;

internal class PolylineDefault : ShapeAllKinds
{
    [JsonProperty]
    private Point[] points;

    [JsonProperty]
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

    private Color strokeColor;

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
        if (InformationForDraw.isDrawed)

            (FigurePtr as Polyline).Points[^1] = new Point(informationForDraw.xExit, informationForDraw.yExit);
        points = (FigurePtr as Polyline).Points.ToArray();

        if (InformationForDraw.ShiftWasPressed)
        {
            (FigurePtr as Polyline).Points.Add(new Point(informationForDraw.xExit, informationForDraw.yExit));
            InformationForDraw.ShiftWasPressed = false;
        }

        StrokeColor = informationForDraw.StrokeColor;
        StrokeThickness = informationForDraw.Thickness;
    }

    public override void Draw(InformationForDraw informationForDraw)
    {
        FigurePtr = new Polyline()
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
        FigurePtr = new Polyline()
        {
            IsHitTestVisible = false,
        };
        // отрисовОчка
        {
            (FigurePtr as Polyline).Points = new PointCollection(points);
            StrokeColor = strokeColor;
            StrokeThickness = strokeThickness;
        }

        canvas.Children.Add(FigurePtr);
    }
}