using System.Drawing;
using HueShape.Data.Enums;

namespace HueShape.Models.Shapes
{
    internal class Circle : Shape
    {
        public override ShapeType ShapeType
        {
            get { return ShapeType.Circle; }
        }

        public override void Draw(Graphics graphics)
        {
            if (Effect == ShapeEffect.Outlined)
            {
                var pen = new Pen(Color);
                graphics.DrawEllipse(pen, LocationX, LocationY, Width, Height);
                return;
            }
            var solidBrush = new SolidBrush(Color);

            graphics.FillEllipse(solidBrush, LocationX, LocationY, Width, Height);
        }
    }
}