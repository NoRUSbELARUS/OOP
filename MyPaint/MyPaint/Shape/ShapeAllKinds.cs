using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace MyPaint;

public abstract class ShapeAllKinds
{
    [JsonIgnore]
    public abstract Shape FigurePtr { get; set; }
    public abstract void UpdateData(InformationForDraw informationForDraw);
    public abstract void Draw(InformationForDraw informationForDraw);
    public abstract void Draw(Canvas canvas);
}