using System.Drawing;
using System.Windows.Forms;
using HueShape.Data.Enums;

namespace HueShape.Interfaces
{
    internal interface IShape
    {
        int Width { get; set; }
        int Height { get; set; }
        int LocationX { get; set; }
        int LocationY { get; set; }
        Color Color { get; set; }
        ShapeEffect Effect { get; set; }
        ShapeType ShapeType { get; }

        void Draw(Graphics graphics);
        void DrawEdit(Graphics graphics, Point location, bool editing, bool isMoving, Panel bottomRightExtender);
    }
}