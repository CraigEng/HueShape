using System.Drawing;
using System.Windows.Forms;
using HueShape.Data.Enums;
using HueShape.Interfaces;

namespace HueShape.Models.Shapes
{
    internal abstract class Shape : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public Color Color { get; set; }
        public ShapeEffect Effect { get; set; }
        public abstract ShapeType ShapeType { get; }
        public abstract void Draw(Graphics graphics);
        public void DrawEdit(Graphics graphics, Point location, bool editing, bool isMoving, Panel bottomRightExtender)
        {
            if (editing && !isMoving)
            {
                var width = location.X - 5 - LocationX;
                var height = location.Y - 5 - LocationY;
                if (width < 2 || height < 2)
                {
                    width = 2;
                    height = 2;
                }
                Width = width;
                Height = height;
            }

            Draw(graphics);

            graphics.DrawRectangle(Pens.Black, LocationX - 5, LocationY - 5, Width + 10,
                                   Height + 10);

            bottomRightExtender.Location = new Point(LocationX + Width, LocationY + Height);
            bottomRightExtender.Visible = true;
        }
    }
}