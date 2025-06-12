using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace MyPaint;

internal class SelectItemMethods
{
    internal InformationForDraw informationForDraw;
    internal SelectedTool selectedTool;
    internal DefaultTools defaultTools;

    internal void SelectThickness(object sender, RoutedEventArgs e, int index)
    {
        informationForDraw.Thickness = defaultTools.ThicknessesTools[index];
    }

    internal void SelectFillColor(object sender, RoutedEventArgs e, int index)
    {
        informationForDraw.FillColor = defaultTools.ColorsTools[index];
        selectedTool.CurrSelectedFillColor = (sender as Border);
        selectedTool.CurrSelectedFillColor.BorderBrush = Brushes.Maroon;
    }

    internal void SelectStrokeColor(object sender, RoutedEventArgs e, int index)
    {
        informationForDraw.StrokeColor = defaultTools.ColorsTools[index];
        selectedTool.CurrSelectedStrokeColor = (sender as Border);
        selectedTool.CurrSelectedStrokeColor.BorderBrush = Brushes.CornflowerBlue;
    }

    internal void SelectShape(object sender, RoutedEventArgs e, int index)
    {
        InformationForDraw.CurrShapeType = defaultTools.ShapesTools[index];
        selectedTool.CurrSelectedShape = (sender as Button);
        selectedTool.CurrSelectedShape.Background = Brushes.CornflowerBlue;
    }
}