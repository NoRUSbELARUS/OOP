using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace MyPaint;

internal class SelectedTool
{
    private Border? currSelectedFillColor;

    internal Border? CurrSelectedFillColor
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

    internal Border? CurrSelectedStrokeColor
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

    internal Button? CurrSelectedShape
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