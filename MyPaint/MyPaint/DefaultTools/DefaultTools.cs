using System.Windows.Media;
using System.Reflection;

namespace MyPaint;

internal class DefaultTools
{
    internal List<Color> ColorsTools = new List<Color>();
    internal List<int> ThicknessesTools = new List<int>();
    internal List<Type> ShapesTools = new List<Type>();

    internal DefaultTools()
    {
        InitializeColors();
        InitializeThicknesses();
        InitializeShapes();
    }

    private void InitializeColors()
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

    private void InitializeThicknesses()
    {
        ThicknessesTools.Add(2);
        ThicknessesTools.Add(4);
        ThicknessesTools.Add(10);
        ThicknessesTools.Add(6);
        ThicknessesTools.Add(8);
        ThicknessesTools.Sort();
    }

    private void InitializeShapes()
    {
        ShapesTools = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(ShapeAllKinds).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .ToList();
    }
    
}