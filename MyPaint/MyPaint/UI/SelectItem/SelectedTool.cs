using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace MyPaint;

public class SelectedTool
{
    private Border? currSelectedFillColor;

    public Border? CurrSelectedFillColor
    {
        get => currSelectedFillColor;
        set
        {
            if (currSelectedFillColor != null)
                currSelectedFillColor.BorderBrush = Brushes.Transparent;

            currSelectedFillColor = value;
        }
    }

    private Border? currSelectedStrokeColor = null;

    public Border? CurrSelectedStrokeColor
    {
        get => currSelectedStrokeColor;
        set
        {
            if (currSelectedStrokeColor != null)
                currSelectedStrokeColor.BorderBrush = Brushes.Transparent;
            currSelectedStrokeColor = value;
        }
    }

    private Button? currSelectedShape = null;

    public Button? CurrSelectedShape
    {
        get => currSelectedShape;
        set
        {
            if (currSelectedShape != null)
                currSelectedShape.Background = Brushes.Transparent;
            currSelectedShape = value;
        }
    }
}