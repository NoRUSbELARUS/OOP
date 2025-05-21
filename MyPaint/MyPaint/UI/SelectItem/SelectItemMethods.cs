using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace MyPaint;

public class SelectItemMethods
{
    public InformationForDraw informationForDraw;
    public SelectedTool selectedTool;
    public DefaultTools defaultTools;
    
    public void SelectThickness(object sender, RoutedEventArgs e, int index)
    {
        informationForDraw.Thickness = defaultTools.ThicknessesTools[index];
    }

    public void SelectFillColor(object sender, RoutedEventArgs e, int index)
    {
        informationForDraw.FillColor = defaultTools.ColorsTools[index];
        selectedTool.CurrSelectedFillColor = (sender as Border);
        selectedTool.CurrSelectedFillColor.BorderBrush = Brushes.Maroon;
    }

    public void SelectStrokeColor(object sender, RoutedEventArgs e, int index)
    {
        informationForDraw.StrokeColor = defaultTools.ColorsTools[index];
        selectedTool.CurrSelectedStrokeColor = (sender as Border);
        selectedTool.CurrSelectedStrokeColor.BorderBrush = Brushes.CornflowerBlue;
    }

    public void SelectShape(object sender, RoutedEventArgs e, int index)
    {
        InformationForDraw.CurrShapeType = defaultTools.ShapesTools[index];
        selectedTool.CurrSelectedShape = (sender as Button);
        selectedTool.CurrSelectedShape.Background = Brushes.CornflowerBlue;
    }
}