using System.Windows.Media;
using System.Reflection;

namespace MyPaint;

public class DefaultTools
{
    public List<Color> ColorsTools = new List<Color>();
    public List<int> ThicknessesTools = new List<int>();
    public List<Type> ShapesTools = new List<Type>();

    public DefaultTools()
    {
        InitializeColors();
        InitializeThicknesses();
        InitializeShapes();
    }

    void InitializeColors()
    {
        ColorsTools.Add(Colors.Black);
        ColorsTools.Add(Colors.White);
        ColorsTools.Add(Colors.Red);
        ColorsTools.Add(Colors.Orange);
        ColorsTools.Add(Colors.Yellow);
        ColorsTools.Add(Colors.Green);
        ColorsTools.Add(Colors.CornflowerBlue);
        ColorsTools.Add(Colors.Blue);
        ColorsTools.Add(Colors.Purple);
        ColorsTools.Add(Colors.Transparent);
        ColorsTools.Add(Colors.Gray);
        ColorsTools.Add(Colors.Black);
    }

    void InitializeThicknesses()
    {
        ThicknessesTools.Add(2);
        ThicknessesTools.Add(4);
        ThicknessesTools.Add(10);
        ThicknessesTools.Add(6);
        ThicknessesTools.Add(8);
        ThicknessesTools.Sort();
    }

    void InitializeShapes()
    {
        ShapesTools = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(ShapeAllKinds).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .ToList();
    }
    
}