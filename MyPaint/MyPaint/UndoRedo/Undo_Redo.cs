using System.Windows.Shapes;

namespace MyPaint;

public class Undo_Redo
{
    public Stack<Shape> ShapeUndoStack = new Stack<Shape>();
    public Stack<ShapeAllKinds> ShapeAllKinds_UndoStack = new Stack<ShapeAllKinds>();
    public InformationForDraw informationForDraw { get; set; }
    
    
    public void Redo()
    {
        if (ShapeUndoStack.Count > 0)
        {
            InformationForDraw.CanvasForDrawing.Children.Add(ShapeUndoStack.Pop());
            InformationForDraw.ShapesOnCanvas.Add(ShapeAllKinds_UndoStack.Pop());
        }
    }

    public void Undo()
    {
        if (InformationForDraw.CanvasForDrawing.Children.Count > 0)
        {
            ShapeUndoStack.Push((Shape)InformationForDraw.CanvasForDrawing.Children[InformationForDraw.CanvasForDrawing.Children.Count - 1]);
            InformationForDraw.CanvasForDrawing.Children.RemoveAt(InformationForDraw.CanvasForDrawing.Children.Count - 1);
            ShapeAllKinds_UndoStack.Push(InformationForDraw.ShapesOnCanvas[InformationForDraw.ShapesOnCanvas.Count - 1]);
            InformationForDraw.ShapesOnCanvas.RemoveAt(InformationForDraw.ShapesOnCanvas.Count - 1);
        }
    }
    
}