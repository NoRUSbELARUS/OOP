using System.Windows;
using System.Windows.Input;

namespace MyPaint;

public partial class MainWindow : Window
{
    private void BtnUndo_OnClick(object sender, RoutedEventArgs e)
    {
        undoRedo.Undo();
    }

    private void BtnRedo_OnClick(object sender, RoutedEventArgs e)
    {
        undoRedo.Redo();
    }

    private void BtnThicknesses_OnClick(object sender, EventArgs e)
    {
        InformationForDraw.PopupThicknesses.IsOpen 
            = !InformationForDraw.PopupThicknesses.IsOpen;
    }

    private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            InformationForDraw.ShiftWasPressed = true;
    }
    
    private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        undoRedo.Undo();
    }

    private void RedoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        undoRedo.Redo();
    }
}