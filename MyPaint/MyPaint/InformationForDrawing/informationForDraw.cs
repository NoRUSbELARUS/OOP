using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MyPaint;

public class InformationForDraw
{
    public double xEnter;
    public double yEnter;
    public double xExit;
    public double yExit;

    public Color FillColor;
    public Color StrokeColor;
    
    public int Thickness = 1;
    
    public static bool isDrawed = false;
    public static bool IsPressed = false;
    public static bool ShiftWasPressed = false;
    
    public static int ColorNumber = 1;

    public static Type CurrShapeType = typeof(EllipseDefault);
    
    public static List<ShapeAllKinds> ShapesOnCanvas = new List<ShapeAllKinds>();
    public static Canvas? CanvasForDrawing;

    public static UniformGrid UniColors;
    public static UniformGrid UniShapes;

    public static Popup PopupThicknesses;
}