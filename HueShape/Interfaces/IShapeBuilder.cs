using System.Drawing;
using HueShape.Data.Enums;

namespace HueShape.Interfaces
{
    internal interface IShapeBuilder
    {
        ShapeType ShapeType { get; set; }
        Color Color { get; set; }
        ShapeEffect Effect { get; set; }
        IShape Build(int width, int height, int locationX, int locationY);
    }
}