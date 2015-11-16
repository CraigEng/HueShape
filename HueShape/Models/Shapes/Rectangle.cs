using System.Drawing;
using HueShape.Data.Enums;

namespace HueShape.Models.Shapes
{
    internal class Rectangle : Shape
    {
        public override ShapeType ShapeType
        {
            get { return ShapeType.Rectangle; }
        }

        public override void Draw(Graphics graphics)
        {
            if (Effect == ShapeEffect.Outlined)
            {
                var pen = new Pen(Color);
                graphics.DrawRectangle(pen, LocationX, LocationY, Width, Height);
                return;
            }
            var solidBrush = new SolidBrush(Color);

            graphics.FillRectangle(solidBrush, LocationX, LocationY, Width, Height);
        }
    }
}